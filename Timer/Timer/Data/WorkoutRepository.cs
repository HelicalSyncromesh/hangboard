using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using Timer.Models;

namespace Timer.Data
{
    public class WorkoutRepository : IWorkout
    {
        public WorkoutDefinition Load(int id)
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(WorkoutDefinition)).Assembly;
            var stream = assembly.GetManifestResourceStream("Timer.Workouts.SimpleWorkout.xml");

            //foreach (var res in assembly.GetManifestResourceNames())
            //    System.Diagnostics.Debug.WriteLine("found resource: " + res);

            WorkoutDefinition definition;
            using (var reader = new StreamReader(stream))
            {
                var serializer = new XmlSerializer(typeof(WorkoutDefinition));
                definition = (WorkoutDefinition)serializer.Deserialize(reader);
            }

            return definition;
        }
    }
}
