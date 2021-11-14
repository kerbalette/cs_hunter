using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;

namespace crowdstrike.library.Helpers
{
    public class FormSerializer
    {
        public string Serialize(object value)
        {
            Type inputType = value.GetType();
            string finish = "";
            var result = new List<KeyValuePair<string, string>>();
            foreach (PropertyInfo property in inputType.GetProperties())
            {
               // result.Add(new KeyValuePair<string, string>(property.Name, value.));
                finish = property.Name;
            }
            return finish;



        }
    }
}
