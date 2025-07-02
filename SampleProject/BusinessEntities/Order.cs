using Common.Extensions;
using System;
using System.Collections.Generic;

namespace BusinessEntities
{
    public class Order : IdObject
    {
        private readonly List<Guid> _products = new List<Guid>();
        private string _address;

        public string Address
        {
            get => _address;
            private set => _address = value;
        }

        public List<Guid> Products
        {
            get => _products;
            private set => _products.Initialize(value);
        }

        public void SetAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                throw new ArgumentNullException($"{nameof(address)} was not provided.");
            }
            _address = address;
        }

        public void SetProducts(List<Guid> products)
        {
            if (products == null || products.Count < 1)
            {
                throw new ArgumentNullException($"{nameof(products)} was not provided.");
            }
            _products.Initialize(products);
        }
    }
}