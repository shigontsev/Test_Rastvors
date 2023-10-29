using Microsoft.EntityFrameworkCore;
using Rastvors.Common.Entities;
using Rastvors.DAL.Interfaces;

namespace Rastvors.DAL.DAO
{
    public class RastvorsManagerDAO : IRastvorsManagerDAO
    {
        private ApplicationDBContext _db;

        public IEnumerable<Component> GetAllComponents()
        {
            using (_db = new ApplicationDBContext())
            {
                return _db.Components.ToList();
            }
        }

        public IEnumerable<Rastvor> GetAllRastvors()
        {
            using (_db = new ApplicationDBContext())
            {
                return _db.Rastvors.Include(x=>x.Structures).ThenInclude(y=>y.Component).ToList();
            }
        }

        public bool Save(IEnumerable<Rastvor> rastvors)
        {
            var input_rastvors = rastvors.ToList();

            foreach (var rastvor in input_rastvors)
            {
                if(!rastvor.IsCorrectStructure())
                {
                    return false;
                }
            }

            using (_db = new ApplicationDBContext())
            {
                using (var tr = _db.Database.BeginTransaction())
                {
                    try
                    {
                        //Если "rastvors" не строк то очищается таблица с растворами
                        if (input_rastvors.Count == 0) 
                        { 
                            if (_db.Rastvors.Count() > 0)
                            {
                                _db.Rastvors.RemoveRange(_db.Rastvors);
                                _db.SaveChanges();
                            }

                            tr.Commit();

                            return true;
                        }

                        //Список новых строк
                        //var new_rastvors = new List<Rastvor>();

                        var db_Rastvors_buffer = new List<Rastvor>();
                        using(var db = new  ApplicationDBContext())
                        {
                            db_Rastvors_buffer.AddRange(db.Rastvors.Include(x => x.Structures).ThenInclude(y => y.Component).ToList());
                        }

                        //Рассматриваем каждый Раствор
                        //foreach (var db_rastvor in _db.Rastvors.Include(x=>x.Structures).ThenInclude(y=>y.Component).ToList())
                        foreach (var db_rastvor in db_Rastvors_buffer)
                        {
                            var check_rastvor = input_rastvors.FirstOrDefault(x => x.Id == db_rastvor.Id);
                            if(check_rastvor == null) 
                            {
                                _db.Rastvors.Remove(db_rastvor);
                                _db.SaveChanges();
                            }
                            else
                            {
                                if(db_rastvor.Value != check_rastvor.Value) 
                                {
                                    //Изменяем объема м3 Раствора если требуется
                                    var buf_rast = _db.Rastvors.FirstOrDefault(x=>x.Id == db_rastvor.Id);
                                    if(buf_rast != null)
                                    {
                                        buf_rast.Value = check_rastvor.Value;
                                        //db_rastvor.Value = check_rastvor.Value;
                                        _db.SaveChanges();
                                    }
                                }

                                //Новые Компонеты для Структуры
                                var new_components = new List<Structure>();
                                //Проверяем Structure
                                foreach(var db_component in db_rastvor.Structures) 
                                {
                                    //var chek_component = check_rastvor.Structures.FirstOrDefault(x =>)

                                    //сохранить данный Компонет в Структуре в БД?
                                    bool b = false;
                                    //Пропускаемый копонент из расмотрения
                                    Structure skip_component = null;

                                    foreach (var component in check_rastvor.Structures)
                                    {
                                        if(db_component.Id == component.Id)
                                        {
                                            //Изменяем количество % Компонента в Структуре если требуется
                                            if(db_component.Value != component.Value)
                                            {
                                                var buf_rast = _db.Rastvors.Include(y=>y.Structures)
                                                    .FirstOrDefault(x => x.Id == db_rastvor.Id);
                                                if (buf_rast != null)
                                                {
                                                    var buf_struct = buf_rast.Structures.FirstOrDefault(x => x.Id == db_component.Id);
                                                    if (buf_struct != null)
                                                    {
                                                        buf_struct.Value = component.Value;
                                                        //db_component.Value = component.Value;
                                                        _db.SaveChanges();
                                                    }
                                                }
                                            }
                                            b = true;
                                            skip_component = component;
                                            break;
                                        }                                        
                                    }

                                    //Удалить данный Компонет в Структуре в БД
                                    if(!b)
                                    {
                                        var garbage = _db.Structures.FirstOrDefault(x => x.Id == db_component.Id);
                                        if(garbage != null)
                                        {
                                            _db.Structures.Remove(garbage);
                                            _db.SaveChanges();
                                        }
                                    }
                                    //Пропускаем копонент из расмотрения
                                    if(skip_component != null)
                                    {
                                        check_rastvor.Structures.Remove(skip_component);
                                    }
                                }

                                //Добавим Копоненты Структуры которые еще не добавили
                                if(check_rastvor.Structures.Count > 0)
                                {
                                    foreach(var component in  check_rastvor.Structures)
                                    {
                                        _db.Structures.Add(new Structure()
                                        {
                                            RastvorId = db_rastvor.Id, 
                                            ComponentId = component.ComponentId,
                                            Value = component.Value
                                        });
                                    }
                                    _db.SaveChanges();
                                }

                                //удаляем уже просмотренный Раствор из входных данных
                                if (check_rastvor is not null)
                                {
                                    input_rastvors.Remove(check_rastvor);
                                }
                            }
                        }


                        //будем добавлять новые растворы из input_rastvors
                        if (input_rastvors.Count > 0)
                        {
                            foreach (var rastvor in input_rastvors)
                            {
                                _db.Rastvors.Add(new Rastvor()
                                {
                                    Name = rastvor.Name,
                                    Value = rastvor.Value
                                });
                                _db.SaveChanges();

                                var current_rastvor = _db.Rastvors.First(x=>x.Name == rastvor.Name);

                                foreach (var structure in rastvor.Structures)
                                {
                                    _db.Structures.Add(new Structure()
                                    {
                                        RastvorId = current_rastvor.Id,
                                        ComponentId = structure.ComponentId,
                                        Value = structure.Value
                                    });
                                }
                                _db.SaveChanges();
                            }
                        }


                        _db.SaveChanges();

                        tr.Commit();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        tr.Rollback();
                        //throw;

                        //MessageBox.Show(ex.Message);
                        return false;
                    }
                }
            }

        }
    }
}
