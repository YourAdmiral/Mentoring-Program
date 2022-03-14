using System;
using System.Collections.Generic;
using System.Linq;
using Task1.DoNotChange;

namespace Task1
{
    public static class LinqTask
    {
        public static IEnumerable<Customer> Linq1(IEnumerable<Customer> customers, decimal limit)
        {
            if (customers == null)
            {
                throw new ArgumentNullException();
            }

            List<Customer> result = customers.Where(customer => customer.Orders.Sum(ord => ord.Total) > limit).ToList();

            return result;
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            if (customers == null || suppliers == null)
            {
                throw new ArgumentNullException();
            }

            List<(Customer customer, IEnumerable<Supplier> suppliers)> result = new List<(Customer customer, IEnumerable<Supplier> suppliers)>();

            foreach (var cust in customers)
            {
                (Customer customer, List<Supplier> suppliers) customerWithSuppliers = (cust, suppliers.Where(sup => sup.Country == cust.Country && sup.City == cust.City).ToList());

                result.Add(customerWithSuppliers);
            }

            return result;
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2UsingGroup(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            if (customers == null || suppliers == null)
            {
                throw new ArgumentNullException();
            }

            return null;
        }

        public static IEnumerable<Customer> Linq3(IEnumerable<Customer> customers, decimal limit)
        {
            if (customers == null)
            {
                throw new ArgumentNullException();
            }

            customers = customers.Where(customer => customer.Orders != null && customer.Orders.Count() > 0);

            List<Customer> result = customers.Where(customer => customer.Orders.Sum(ord => ord.Total) > limit).ToList();

            return result;
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq4(
            IEnumerable<Customer> customers
        )
        {
            if (customers == null)
            {
                throw new ArgumentNullException();
            }

            customers = customers.Where(customer => customer.Orders != null && customer.Orders.Count() > 0);

            List<(Customer customer, DateTime dateOfEntry)> result = new List<(Customer customer, DateTime dateOfEntry)>();

            foreach (var cust in customers)
            {
                DateTime minDate = cust.Orders.Min(order => order.OrderDate);

                (Customer customer, DateTime dateOfEntry) customerWithDate = (cust, minDate);

                result.Add(customerWithDate);
            }

            return result;
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq5(
            IEnumerable<Customer> customers
        )
        {
            if (customers == null)
            {
                throw new ArgumentNullException();
            }

            customers = customers.Where(customer => customer.Orders != null && customer.Orders.Count() > 0);

            List<(Customer customer, DateTime dateOfEntry)> result = new List<(Customer customer, DateTime dateOfEntry)>();

            foreach (var cust in customers)
            {
                DateTime minDate = cust.Orders.Min(order => order.OrderDate);

                (Customer customer, DateTime dateOfEntry) customerWithDate = (cust, minDate);

                result.Add(customerWithDate);
            }

            return result.OrderBy(val => val.dateOfEntry.Year)
                .ThenBy(val => val.dateOfEntry.Month)
                .ThenByDescending(val => val.customer.Orders.Sum(order => order.Total))
                .ThenBy(val => val.customer.CompanyName);
        }

        public static IEnumerable<Customer> Linq6(IEnumerable<Customer> customers)
        {
            if (customers == null)
            {
                throw new ArgumentNullException();
            }

            List<Customer> result = customers.Where(customer => !int.TryParse(customer.PostalCode, out int num) 
            || customer.Region == null 
            || !customer.Phone.Contains(')')
            || !customer.Phone.Contains('(')).ToList();

            return result;
        }

        public static IEnumerable<Linq7CategoryGroup> Linq7(IEnumerable<Product> products)
        {
            /* example of Linq7result

             category - Beverages
	            UnitsInStock - 39
		            price - 18.0000
		            price - 19.0000
	            UnitsInStock - 17
		            price - 18.0000
		            price - 19.0000
             */

            if (products == null)
            {
                throw new ArgumentNullException();
            }

            var groups = products.GroupBy(sup => sup.Category)
                   .Select(g => new Linq7CategoryGroup()
                   {
                       Category = g.First().Category,
                       UnitsInStockGroup = g.Select(g => new Linq7UnitsInStockGroup
                       {
                           UnitsInStock = g.UnitsInStock,
                           Prices = new[] { g.UnitPrice }
                       })
                   }
            );

            return groups;
        }

        public static IEnumerable<(decimal category, IEnumerable<Product> products)> Linq8(
            IEnumerable<Product> products,
            decimal cheap,
            decimal middle,
            decimal expensive
        )
        {
            if (products == null)
            {
                throw new ArgumentNullException();
            }

            return null;
        }

        public static IEnumerable<(string city, int averageIncome, int averageIntensity)> Linq9(
            IEnumerable<Customer> customers
        )
        {
            if (customers == null)
            {
                throw new ArgumentNullException();
            }

            return null;
        }

        public static string Linq10(IEnumerable<Supplier> suppliers)
        {
            if (suppliers == null)
            {
                throw new ArgumentNullException();
            }

            var result = suppliers.GroupBy(sup => sup.Country)
                   .Select(grp => grp.First())
                   .OrderBy(item => item.Country.Length)
                   .ThenBy(item => item.Country)
                   .ToList();

            return string.Join("", result.Select(p => p.Country)); 
        }
    }
}