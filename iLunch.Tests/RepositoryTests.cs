using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using NUnit.Framework;
using iLunch.Dominio;
using iLunch.Repository.Impl;
using iLunch.Repository.Infrastructure;
using iLunch.Repository.Interfaces;
using NHibernate;
using Rhino.Mocks;

namespace iLunch.Tests
{
    class RepositoryTests
    {
        public static ISession _session;
        #region Setup/Teardown

        [TearDown]
        public static void Remove_Entity_Test()
        {
            IUserRepository repository = new UserRepository(_session);
            ICollection<User> todosAntesDeDelete = repository.GetAll();

            foreach (User User in todosAntesDeDelete)
            {
                repository.Delete(User);
            }

            ICollection<User> todosDepoisDeDelete = repository.GetAll();

            Assert.IsTrue(todosDepoisDeDelete.Count == 0);
        }

        #endregion

        [TestFixtureSetUp]
        public static void Setup()
        {
            _session = new MockRepository().DynamicMock<ISession>();
            Configuration cfg = FluentConfigurator.Instance;
            FluentConfigurator.BuildSchema(cfg, true, true);
        }

        [TestFixtureTearDown]
        public static void TearDown()
        {
            Configuration cfg = FluentConfigurator.Instance;
            FluentConfigurator.BuildSchema(cfg, true, false);
        }

        [TestCase]
        public static void Save_Entity_Test()
        {
            IUserRepository repository = new UserRepository(_session);
            User operador = new User
            {
                Login = "Operador Teste",
                Name = "Operador Teste",
                Password = "Password",
            };

            repository.Insert(operador);

            User operadorBd = repository.GetById(operador.Id);

            Assert.AreEqual(operador.Name, operadorBd.Name);
        }

        [TestCase]
        public static void Get_Entity_By_Id()
        {
            long id = 0;
            IUserRepository repository = new UserRepository(_session);
            User operadorBd = null;

            User operador = new User
            {
                Login = "Operador Teste Fabrica",
                Name = "Operador Teste Fabrica",
                Password = "Password Fabrica",
            };

            repository.Insert(operador);

            id = operador.Id;

            operadorBd = repository.GetById(id);

            Assert.That(operadorBd.GetHashCode(), Is.Not.EqualTo(operador.GetHashCode()));
            Assert.That(operadorBd.Id, Is.EqualTo(operador.Id));
        }

        [TestCase]
        public static void Update_Entity_Test()
        {
            const string operadorNameAtualizado = "Operador Teste Update";
            IUserRepository repository = new UserRepository(_session);
            User operador = new User
            {
                Login = "Operador Teste",
                Name = "Operador Teste",
                Password = "Password",
            };

            repository.Insert(operador);


            User operadorBd = repository.GetAll().First();
            operadorBd.Name = operadorNameAtualizado;

            repository.Update(operadorBd);

            operadorBd = repository.GetAll().First();

            Assert.AreEqual(operadorNameAtualizado, operadorBd.Name);
        }
    }
}
