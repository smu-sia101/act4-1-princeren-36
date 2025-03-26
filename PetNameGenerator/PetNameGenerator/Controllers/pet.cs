using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace PetNameGenerator.Controllers
{
    [ApiController]
    [Route("api/pet")]
    public class pet : Controller
    {
        private string[] dogName = new string[]
        {
            "Buddy", "Max", "Charlie", "Rocky", "Rex"
        };
        private string[] catName = new string[]
        {
            "Whiskers", "Mittens", "Luna", "Simba", "Tiger"
        };
        private string[] birdName = new string[]
        {
            "Tweety", "Sky", "Chirpy", "Raven", "Sunny"
        };

        [HttpPost("/api/pet")]
        public IActionResult Post(string animalType, Boolean twoPart)
        {
            Random rnd = new Random();
            int dogIndex = rnd.Next(dogName.Length);
            int catIndex = rnd.Next(catName.Length);
            int birdIndex = rnd.Next(birdName.Length);

            string[] selectedNames;
            if (animalType.ToLower() == "dog")
            {
                selectedNames = dogName;
            }
            else if (animalType.ToLower() == "cat")
            {
                selectedNames = catName;

            }
            else if (animalType.ToLower() == "bird")
            {
                selectedNames = birdName;

            }
            else if (animalType == "")
            {
                return BadRequest("The 'animalType' field is required.");
            }
            else
            {
                return BadRequest("Invalid animal type. Please specify 'dog', 'cat', or 'bird'.");
            }

            string name1 = selectedNames[rnd.Next(selectedNames.Length)];

            if (twoPart)
            {
                string name2 = selectedNames[rnd.Next(selectedNames.Length)];
                return Ok(new { AnimalType = animalType, Name = $"{name1}{name2}" });
            }
            else
            {
                return Ok(new { AnimalType = animalType, Name = name1 });
            }

        }
    }
}
