using System;

namespace BusinessEntities
{
    public class Product : IdObject
    {
        private Guid _id;
        private string _name;        
        private decimal _cost;

        public Guid Id
        {
            get => _id;
            private set => _id = value;
        }

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public decimal Cost        
        {
            get => _cost;
            private set => _cost = value;
        }

        public void SetId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException($"{nameof(id)} was not provided.");
            }
            _id = id;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException($"{nameof(name)} was not provided.");
            }
            _name = name;
        }

        public void SetCost(decimal cost)
        {
            if (cost == null || cost <= 0)
            {
                throw new ArgumentNullException( $"{nameof(cost)} was not provided or invalid.");
            }

            _cost = cost;
        }
    }
}