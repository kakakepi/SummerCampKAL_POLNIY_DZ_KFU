using System.Xml.Linq;
using System.Text.Json;
namespace SummerCamp
{
    public static class DataLoader
    {
        public static (List<Camper>, List<Activity>, List<Schedule>) LoadData(string path)
        {
            return path.EndsWith(".xml")
                ? LoadFromXml(path)
                : LoadFromJson(path);
        }

        private static (List<Camper>, List<Activity>, List<Schedule>) LoadFromXml(string path)
        {
            var doc = XDocument.Load(path);

            var campers = doc.Descendants("Camper").Select(x => new Camper
            {
                Id = (int)x.Element("Id"),
                FullName = (string)x.Element("FullName"),
                Age = (int)x.Element("Age"),
                Cabin = (string)x.Element("Cabin"),
                Contacts = new CamperContacts
                {
                    Phone = (string)x.Element("Contacts")?.Element("Phone"),
                    Email = (string)x.Element("Contacts")?.Element("Email")
                },
                Schedules = x.Element("Schedules")?.Elements("Schedule").Select(s => new Schedule
                {
                    Id = (int)s.Element("Id"),
                    ActivityId = (int)s.Element("ActivityId"),
                    Date = DateTime.Parse((string)s.Element("Date")),
                    Time = (string)s.Element("Time")
                }).ToList()
            }).ToList();

            var activities = doc.Descendants("Activity").Select(x => new Activity
            {
                Id = (int)x.Element("Id"),
                Name = (string)x.Element("Name"),
                Location = (string)x.Element("Location"),
                Duration = (int)x.Element("Duration"),
                Instructor = new ActivityInstructor
                {
                    Name = (string)x.Element("Instructor")?.Element("Name"),
                    Phone = (string)x.Element("Instructor")?.Element("Phone")
                }
            }).ToList();

            return (campers, activities, campers.SelectMany(c => c.Schedules).ToList());
        }

        private static (List<Camper>, List<Activity>, List<Schedule>) LoadFromJson(string path)
        {
            var json = File.ReadAllText(path);
            using var doc = JsonDocument.Parse(json);

            var campers = doc.RootElement.GetProperty("Campers").EnumerateArray().Select(c => new Camper
            {
                Id = c.GetProperty("Id").GetInt32(),
                FullName = c.GetProperty("FullName").GetString(),
                Age = c.GetProperty("Age").GetInt32(),
                Cabin = c.GetProperty("Cabin").GetString(),
                Contacts = new CamperContacts
                {
                    Phone = c.GetProperty("Contacts").GetProperty("Phone").GetString(),
                    Email = c.GetProperty("Contacts").GetProperty("Email").GetString()
                },
                Schedules = c.GetProperty("Schedules").EnumerateArray().Select(s => new Schedule
                {
                    Id = s.GetProperty("Id").GetInt32(),
                    ActivityId = s.GetProperty("ActivityId").GetInt32(),
                    Date = DateTime.Parse(s.GetProperty("Date").GetString()),
                    Time = s.GetProperty("Time").GetString()
                }).ToList()
            }).ToList();

            var activities = doc.RootElement.GetProperty("Activities").EnumerateArray().Select(a => new Activity
            {
                Id = a.GetProperty("Id").GetInt32(),
                Name = a.GetProperty("Name").GetString(),
                Location = a.GetProperty("Location").GetString(),
                Duration = a.GetProperty("Duration").GetInt32(),
                Instructor = new ActivityInstructor
                {
                    Name = a.GetProperty("Instructor").GetProperty("Name").GetString(),
                    Phone = a.GetProperty("Instructor").GetProperty("Phone").GetString()
                }
            }).ToList();

            return (campers, activities, campers.SelectMany(c => c.Schedules).ToList());
        }
    }
}