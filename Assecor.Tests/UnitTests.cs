using Assecor.Controllers;
using Assecor.Tests.MockRepository;

using BusinessDTO;

using Domain.Core;
using Domain.EF;

using Microsoft.AspNetCore.Mvc;

using Moq.AutoMock;

using Newtonsoft.Json;

using Services;

namespace Assecor.Tests
{
    public class Tests
    {
        private PersonsController personsController;

        private List<Color> _colors = new List<Color>
        {
            new Color { Id = 1, Farbe = "first" },
            new Color { Id = 2, Farbe = "second" }
        };

        private List<Person> _persons;


        [SetUp]
        public void Setup()
        {
            var mocker = new AutoMocker();
            
            _persons = new List<Person>
            {
                new Person
                {
                    Id = 1, City = "city", LastName = "lastname", Name = "name", ZipCode = 12345,
                    Color = _colors[0]
                },
                new Person
                {
                    Id = 2, City = "city2", LastName = "lastname2", Name = "name2", ZipCode = 23456,
                    Color = _colors[1]
                },
                new Person
                {
                    Id = 3,
                    City = "city3",
                    LastName = "lastname3",
                    Name = "name3",
                    ZipCode = 34567,
                    Color = _colors[1]
                },
            };

            var personContext = mocker.CreateInstance<PersonContext>();
            personContext.Colors.AddRange(_colors);
            personContext.Persons.AddRange(_persons);

            var mockUOF = new MockUnitOfWork(personContext);

            var personServ = new PersonService(mockUOF);
            var colorServ = new ColorService(mockUOF);

            personsController = new PersonsController(personServ, colorServ);
        }

        [Test]
        public void TestGetAll()
        {
            var result = ((JsonResult)personsController.Get()).Value;
            
            List<Object> collection = new List<Object>((IEnumerable<Object>)result);
            
            Assert.That(collection.Count, Is.EqualTo(3));
        }
        [Test]
        public void TestGet()
        {
            var testPersonId = 2;
            var jsResult = (JsonResult)personsController.Get(testPersonId);

            var json = JsonConvert.SerializeObject(jsResult.Value);

            var personDto = JsonConvert.DeserializeObject<PersonDTO>(json);
            
            Assert.That(personDto.Id, Is.EqualTo(testPersonId));
            Assert.That(personDto.ZipCode, Is.EqualTo(_persons.First(x=>x.Id == testPersonId).ZipCode));
        }

        [Test]
        public void TestGetByColor()
        {
            var testColorId = 2;
            
            var jsResult = ((JsonResult) personsController.GetByColor(testColorId)).Value;
            
            List<Object> collection = new List<Object>((IEnumerable<Object>)jsResult);

            Assert.That(collection.Count, Is.EqualTo(_persons.Where(x => x.Color.Id == testColorId).Count()));
        }

        [TearDownAttribute]
        public void TearDown()
        {
            personsController.Dispose();
        }
    }
}
