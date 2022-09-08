
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.App.Model;

namespace TestePleno.App.Services
{
    public abstract class Repository
    {
        private static List<IModel> _fakeDatabase = new List<IModel>();

        public static void Insert(IModel model)
        {
            if (model.Id == Guid.Empty)
                throw new Exception("Não é possível salvar um registro com Id não preenchido");

            var modelAlreadyExists = _fakeDatabase.Any(savedModel => savedModel.Id == model.Id);
            if (modelAlreadyExists)
                throw new Exception($"Já existe um registro para a entidade '{model.GetType().Name}' com o Id '{model.Id}'");

             _fakeDatabase.Add(model);
        }

        public static void Update(IModel model)
        {
            var updatingModel = _fakeDatabase.FirstOrDefault(savedModel => savedModel.Id == model.Id);
            if (updatingModel == null)
                throw new Exception($"Não há registros para a entidade '{model.GetType().Name}' com Id '{model.Id}'");

            _fakeDatabase.Remove(updatingModel);
            _fakeDatabase.Add(model);
        }

        public static T GetById<T>(Guid id)
        {
            var model = _fakeDatabase.FirstOrDefault(savedModel => savedModel.Id == id);
            return (T)model;
        }

        public static List<T> GetAll<T>()
        {
            var allModels = _fakeDatabase.Where(savedModel => savedModel.GetType().IsAssignableFrom(typeof(T)));
            var convertedModels = allModels.Select(genericModel => (T)genericModel).ToList();
            return convertedModels;
        }
    }
}
