using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tenant_App.Utilities.Enrollment
{

	[AttributeUsage(AttributeTargets.Property)]
	public class IgnorePropertyCheckAttribute : Attribute
	{
	}
	public static class CheckNullProperty
    {

        /// <summary>
        /// This method is used to itrate through all the fields/properties of a given object or class to check for null fields
        /// The method should return true if at least one filed is not null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>

        // 
        public static bool CheckForNoneNullPropert<T>(T model)
        {
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(model);
                if (value != null)
                {
                    return true; // Found at least one none null property is found
                }
            }

            return false; // all properties are null
        }

        /// <summary>
        /// This method is used to assert that a class or method has all it's fields/properties completely filled 
        /// it will return true if this is true and return false if not
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool CheckForCompleteModel<T>(T model)
        {
            var properties = typeof(T).GetProperties();
            int propertyCount = properties.Length;
            int count = 0;
            foreach (var property in properties)
            {
				var ignoreCheckAttribute = property.GetCustomAttributes(typeof(IgnorePropertyCheckAttribute), true)
				.FirstOrDefault() as IgnorePropertyCheckAttribute;

				if (ignoreCheckAttribute != null)
				{
                    propertyCount--;
					continue; // Skip properties marked with the IgnorePropertyCheckAttribute
				}

				var value = property.GetValue(model);
                if (value != null)
                {
                    count += 1; // Found none null property and increase the count of none null properties
                }
            }

            if(count == propertyCount)
            {
                return true; // The model properties are all filled
            }
            return false; // Atleast one property is null 
        }

         public static bool CheckForAllNullModel<T>(T model)
        {
            var properties = typeof(T).GetProperties();
            int propertyCount = properties.Length;
            int count = 0;
            foreach (var property in properties)
            {
				var value = property.GetValue(model);
                if (value == null)
                {
                    count += 1; // Found one null property and increase the count of none null properties
                }
            }

            if(count == propertyCount)
            {
                return true; // The model properties are all null
            }
            return false; // Atleast one property is not null 
        }



    }
}
