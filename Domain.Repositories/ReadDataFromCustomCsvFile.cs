using Domain.Core;
using Domain.Interface;

using Microsoft.Extensions.Configuration;

using System.Text;
using Domain.Data;

namespace Domain.Repositories
{
    public class ReadCustomCsvFile :IReadPersonFromFile
    {
        private readonly IConfiguration _configuration;
        public ReadCustomCsvFile(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<Person> ReadPersons()
        {

            List<Person> persons = new List<Person>();
            var path = _configuration.GetConnectionString("Default");

            using (var fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var rec = new StreamReader(fs, Encoding.UTF8))
                {
                    var file = rec.ReadToEnd();
                    file = file.Replace("\r\n", ",");
                    file = file.Replace(",,", ",");

                    var elements = file.Split(',');
                    elements = elements.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                    int currentId = 1;

                    for (int position = 0; position < elements.Length; position = position + 4)
                    {
                        int zipCode;
                        int.TryParse(elements[position + 2].Trim().Split(" ").FirstOrDefault(), out zipCode);

                        var city = elements[position + 2].Replace(zipCode.ToString(), string.Empty).Trim();

                        int colorId;
                        int.TryParse(elements[position + 3], out colorId);
                        var color = Colors.ExistedColors.ToList().Find(x => x.Id == colorId);

                        persons.Add(
                            new Person()
                            {
                                Id = currentId,
                                Name = elements[position].Trim(),
                                LastName = elements[position + 1].Trim(),
                                ZipCode = zipCode,
                                City = city,
                                Color = color
                            });
                        currentId++;
                    }
                }
            }

            return persons;
        }


    }
}
