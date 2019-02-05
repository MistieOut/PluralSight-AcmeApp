﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    public class VendorRepository
    {

        private List<Vendor> vendors;

        /// <summary>
        /// Retrieve one vendor.
        /// </summary>
        public Vendor Retrieve(int vendorId)
        {
            // Create the instance of the Vendor class
            Vendor vendor = new Vendor();

            // Code that retrieves the defined customer

            // Temporary hard coded values to return 
            if (vendorId == 1)
            {
                vendor.VendorId = 1;
                vendor.CompanyName = "ABC Corp";
                vendor.Email = "abc@abc.com";
            }
            return vendor;
        }

        /// <summary>
        /// Retrieves all of the approved vendors
        /// </summary>
        /// <returns></returns>
        //public Vendor[] RetrieveArray()
        //{
        //    var vendors = new Vendor[2]
        //    {
        //        new Vendor()
        //        { VendorId = 5, CompanyName = "ABC Corp", Email = "abc@abc.com" },
        //        new Vendor()
        //        { VendorId = 8, CompanyName = "XYZ Inc", Email = "xyz@yxz.com" },
        //    };

        //    return vendors;
        //}


        /// <summary>
        /// Retrieves all of the approved vendors.
        /// </summary>
        public IEnumerable<Vendor> Retrieve()
        {
            if (vendors == null)
            {
                vendors = new List<Vendor>();

                vendors.Add(new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" });
                vendors.Add(new Vendor() { VendorId = 2, CompanyName = "XYZ Inc", Email = "xyz@xyz.com" });
            }

            for (int i = 0; i < vendors.Count; i++)
            {
                Console.WriteLine(vendors[i]);
            }

            foreach (var vendor in vendors)
            {
                //Console.WriteLine(vendor);
            }
            //Console.WriteLine(vendors[1]);

            return vendors;
        }

        /// <summary>
        /// Retrieves all of the approved vendors.
        /// </summary>
        public IEnumerable<Vendor> RetrieveAll()
        {
            var vendors = new List<Vendor>()
            {
                {new Vendor()
                { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" }},
                {new Vendor()
                { VendorId = 2, CompanyName = "XYZ Inc", Email = "xyz@xyz.com" }},
                {new Vendor()
                { VendorId = 12, CompanyName = "EFG Ltd", Email = "efg@efg.com" }},
                {new Vendor()
                { VendorId = 17, CompanyName = "HIJ AG", Email = "hij@hij.com" }},
                {new Vendor()
                { VendorId = 22, CompanyName = "Amalgamated Toys", Email = "a@abc.com" }},
                {new Vendor()
                { VendorId = 28, CompanyName = "Toy Blocks Inc", Email = "blocks@abc.com" }},
                {new Vendor()
                { VendorId = 31, CompanyName = "Home Products Inc", Email = "home@abc.com" }},
                {new Vendor()
                { VendorId = 35, CompanyName = "Car Toys", Email = "car@abc.com" }},
                {new Vendor()
                { VendorId = 42, CompanyName = "Toys for Fun", Email = "fun@abc.com" }},
            };

            return vendors;
        }

            public IEnumerable<Vendor> RetrieveWithIterator()
        {
            //Get the data from the database
            this.Retrieve();

            foreach (var vendor in vendors)
            {
                Console.WriteLine($"Vendor Id: {vendor.VendorId}");
                yield return vendor;
            }
        }

        /// <summary>
        /// Retrieves all of the approved vendors
        /// </summary>
        /// <returns></returns>
        //public Dictionary<string, Vendor> RetrieveWithKeys()
        //{
        //    var vendors = new Dictionary<string, Vendor>()
        //    {
        //        { "ABC Corp", new Vendor()
        //            { VendorId = 5, CompanyName = "ABC Corp", Email = "abc@abc.com" }},
        //        { "XYZ Inc", new Vendor()
        //            { VendorId = 8, CompanyName = "XYZ Inc", Email = "xyz@yxz.com" }},
        //    };

        //    foreach (var element in vendors)
        //    {
        //        var vendor = element.Value;
        //        var key = element.Key;
        //        Console.WriteLine($"Key: {key} Value: {vendor}"); 
        //    } 

            //foreach (var vendor in vendors.Values)
            //{
            //    Console.WriteLine(vendor);
            //}

            //foreach (var companyName in vendors.Keys)
            //{
            //    Console.WriteLine(vendors[companyName]);
            //}
            
            ////Console.WriteLine(vendors["XYZ Inc"]);

            //if (vendors.ContainsKey("XYZ"))
            //{
            //    Console.WriteLine(vendors["XYZ"]);
            //}

            //Vendor vendor;
            //if (vendors.TryGetValue("XYZ", out vendor))
            //{
            //    Console.WriteLine(vendor);
            //}
        //    return vendors;
        //}

        public T RetreivalValue<T>(string sql, T defaultValue)
        {
            //Call the database to retrieve the value
            //If no value is returned, return the default value
            T value = defaultValue;

            return value;
        }

        public bool Save(Vendor vendor)
        {
            var success = true;

            // Code that saves the vendor

            return success;
        }


    }
}
