using System;
using System.Xml.Linq;
using System.Text.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace SummerCamp
{
    public static class DataLoader
    {
        public static (List<Camper> Campers, List<Activity> Activities, List<Schedule> Schedules) LoadData(string path)
        {
            return path.EndsWith(".xml", StringComparison.OrdinalIgnoreCase)
                ? LoadFromXml(path)
                : LoadFromJson(path);
        }

        private static (List<Camper>, List<Activity>, List<Schedule>) LoadFromXml(string path)
        {
            var doc = XDocument.Load(path);

            var activities = doc.Descendants("Activity")
                .Select(a => new Activity
                {
                    Id = (int?)a.Element("Id") ?? throw new InvalidDataException("Activity Id is required"),
                    Name = (string)a.Element("Name") ?? "Без названия",
                    Location = (string)a.Element("Location") ?? "Не указано",
                    Duration = (int?)a.Element("Duration") ?? 0,
                    Instructor = new ActivityInstructor
                    {
                        Name = (string)a.Element("Instructor")?.Element("Name") ?? "Инструктор не указан",
                        Phone = (string)a.Element("Instructor")?.Element("Phone") ?? string.Empty
                    }
                }).ToList();

            var campers = doc.Descendants("Camper")
                .Select(c =>
                {
                    var camperId = (int?)c.Element("Id") ?? throw new InvalidDataException("Camper Id is required");

                    var schedules = c.Element("Schedules")?.Elements("Schedule")
                        .Select(s =>
                        {
                            var activityId = (int?)s.Element("ActivityId")
                                ?? throw new InvalidDataException("ActivityId is required in Schedule");

                            var foundActivity = activities.FirstOrDefault(a => a.Id == activityId);
                            if (foundActivity == null)
                            {
                                Console.WriteLine($"Warning: Activity with ID {activityId} not found for Camper {camperId}. Skipping schedule.");
                                return null;
                            }

                            return new Schedule
                            {
                                Id = (int?)s.Element("Id") ?? 0,
                                ActivityId = activityId,
                                CamperId = camperId,
                                Time = (string)s.Element("Time") ?? "00:00",
                                Activity = foundActivity
                            };
                        })
                        .Where(schedule => schedule != null)
                        .Cast<Schedule>()
                        .ToList() ?? new List<Schedule>();

                    return new Camper
                    {
                        Id = camperId,
                        FullName = (string)c.Element("FullName") ?? "Неизвестный участник",
                        Age = (int?)c.Element("Age") ?? 0,
                        Cabin = (string)c.Element("Cabin") ?? "Без домика",
                        Contacts = new CamperContacts
                        {
                            Phone = (string)c.Element("Contacts")?.Element("Phone") ?? string.Empty,
                            Email = (string)c.Element("Contacts")?.Element("Email") ?? string.Empty
                        },
                        Schedules = schedules
                    };
                })
                .ToList();

            var allSchedules = campers.SelectMany(c => c.Schedules).ToList();
            return (campers, activities, allSchedules);
        }

        private static (List<Camper>, List<Activity>, List<Schedule>) LoadFromJson(string path)
        {
            using var stream = new FileStream(path, FileMode.Open);
            using var doc = JsonDocument.Parse(stream);

            var activities = new List<Activity>();
            foreach (var a in doc.RootElement.GetProperty("Activities").EnumerateArray())
            {
                var activity = new Activity
                {
                    Id = a.TryGetProperty("Id", out var id)
                            ? id.GetInt32()
                            : throw new InvalidDataException("Activity Id required"),
                    Name = a.TryGetProperty("Name", out var name)
                            ? name.GetString()
                            : "Без названия",
                    Location = a.TryGetProperty("Location", out var loc)
                            ? loc.GetString()
                            : "Не указано",
                    Duration = a.TryGetProperty("Duration", out var dur)
                            ? dur.GetInt32()
                            : 0,
                    Instructor = new ActivityInstructor
                    {
                        Name = a.TryGetProperty("Instructor", out var instructorJson)
                                ? instructorJson.GetProperty("Name").GetString() ?? "Инструктор не указан"
                                : "Инструктор не указан",
                        Phone = a.TryGetProperty("Instructor", out var instructorJson2)
                                ? instructorJson2.GetProperty("Phone").GetString() ?? string.Empty
                                : string.Empty,
                    }
                };

                activities.Add(activity);
            }

            var campers = new List<Camper>();
            foreach (var c in doc.RootElement.GetProperty("Campers").EnumerateArray())
            {
                var camperId = c.TryGetProperty("Id", out var id)
                    ? id.GetInt32()
                    : throw new InvalidDataException("Camper Id required");

                var camper = new Camper
                {
                    Id = camperId,
                    FullName = c.TryGetProperty("FullName", out var name)
                                ? name.GetString()
                                : "Неизвестный участник",
                    Age = c.TryGetProperty("Age", out var age)
                            ? age.GetInt32()
                            : 0,
                    Cabin = c.TryGetProperty("Cabin", out var cabin)
                              ? cabin.GetString()
                              : "Без домика",
                    Contacts = new CamperContacts
                    {
                        Phone = c.TryGetProperty("Contacts", out var contactsJson)
                                ? contactsJson.GetProperty("Phone").GetString() ?? string.Empty
                                : string.Empty,
                        Email = c.TryGetProperty("Contacts", out var contactsJson2)
                                ? contactsJson2.GetProperty("Email").GetString() ?? string.Empty
                                : string.Empty,
                    },
                    Schedules = new List<Schedule>()
                };

                if (c.TryGetProperty("Schedules", out var schedulesJson))
                {
                    foreach (var s in schedulesJson.EnumerateArray())
                    {
                        var activityId = s.TryGetProperty("ActivityId", out var aId)
                            ? aId.GetInt32()
                            : throw new InvalidDataException("ActivityId required in Schedule");

                        var foundActivity = activities.FirstOrDefault(a => a.Id == activityId);
                        if (foundActivity == null)
                        {
                            Console.WriteLine($"Warning: Activity with ID {activityId} not found for Camper {camperId}. Skipping schedule.");
                            continue;
                        }

                        var schedule = new Schedule
                        {
                            Id = s.TryGetProperty("Id", out var sId) ? sId.GetInt32() : 0,
                            ActivityId = activityId,
                            CamperId = camperId,
                            Time = s.TryGetProperty("Time", out var time) ? time.GetString() : "00:00",
                            Activity = foundActivity
                        };

                        camper.Schedules.Add(schedule);
                    }
                }

                campers.Add(camper);
            }

            var allSchedules = campers.SelectMany(c => c.Schedules).ToList();
            return (campers, activities, allSchedules);
        }
    }
}
