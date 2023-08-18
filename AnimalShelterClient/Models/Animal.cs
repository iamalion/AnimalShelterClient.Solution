using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AnimalShelterClient.Models
{
    public class AnimalShelterClient
    {
         public int AnimalId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Species { get; set; }
        public string Breed { get; set; }
        [Range(0, 30, ErrorMessage ="Age must be between 0 and 30")]
        public int Age { get; set; }
        public string Description { get; set; }
        public bool Available { get; set; }
        public static List<Animal> GetAnimals()
        {
            var apiCallTask = ApiHelper.GetAll();
            var result = apiCallTask.Result;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
            List<Animal> animalList = JsonConvert.DeserializeObject<List<Animal>>(jsonResponse.ToString());

            return animalList;
        }
    }
}