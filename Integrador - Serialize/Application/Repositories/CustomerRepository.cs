using System;
using System.Collections.Generic;
using System.Linq;
using Application.Exceptions;
using Application.DataAcces;

using Application.Models;
namespace Application.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>
    {
        private static List<Customer> customers;

        #region -- Los datos no se encuentran guardados más que en memoria --

        static CustomerRepository()
        {
            // Carga de 100 clientes de forma predeterminada
            customers = new List<Customer>();

            for (int i = 0; i < 20; i++)
            {
                var customer = new Customer();
                customer.Id = i + 1;
                customer.Name = "CustomerName" + customer.Id;
                customer.LastName = "CustomerLastname" + customer.Id;
                customer.Age = 20 + (int)customer.Id;

                customers.Add(customer);
            }
        }

        #endregion

        public override void Create(Customer entity)
        {
            try
            {
                long lastId = (long)(customers[customers.Count - 1]).Id;
                entity.Id = lastId + 1;
                if (customers != entity)
                {
                    customers.Add(entity);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw new TechnicalException(
                    string.Format("No se pudo crear el cliente \"{0} {1}\".", entity.Name, entity.LastName),
                    ex);
            }

        }
        public override List<Customer> GetAll()
        {
            // Devuelve una nueva lista ordenada por ID
            //TODO: resolver el error
            CustomerRepository.customers.Sort((x, y) => x.Id.CompareTo(y.Id));

            return customers.ToList();
        }
        public List<Customer> GetAll(string path)
        {
            CustomerSerializer customerSerializer = new CustomerSerializer();
            customers.AddRange(customerSerializer.Read(path));
            return customers;
        }

        public override Customer GetById(long entityId)
        {
            Customer customer = null;

            foreach (Customer c in CustomerRepository.customers)
            {
                if (c.Id == entityId)
                {
                    customer = c;
                    break;
                }
            }

            return customer;
        }

        public override void Remove(Customer entity)
        {
            Customer customer = this.GetById(entity.Id);

            if (!(customer is null))
            {
                CustomerRepository.customers.Remove(customer);
            }
        }

        public override void Update(Customer entity)
        {
            if (!(entity is null))
            {
                for (int i = 0; i < CustomerRepository.customers.Count; i++)
                {
                    if (CustomerRepository.customers[i].Id == entity.Id)
                    {
                        CustomerRepository.customers[i] = entity;
                        break;
                    }
                }

                //foreach(Customer c in CustomerRepository.customers)
                //{
                //    if (c.Id == customer.Id)
                //    {
                //        CustomerRepository.customers.Remove(c);
                //        CustomerRepository.customers.Add(customer);
                //    }
                //}
            }
        }

        public List<Customer> LoadFromFile(string path)
        {

            CustomerSerializer customerSerializer = new CustomerSerializer();
            customers.AddRange(customerSerializer.Read(path));
            return customers;
        }

        public bool SaveToFile(List<Customer> customers)
        {
            CustomerSerializer customerSerializer = new CustomerSerializer();
            return customerSerializer.Save(customers);
        }

    }
}
