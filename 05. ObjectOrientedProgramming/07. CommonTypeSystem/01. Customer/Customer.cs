using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Customer : ICloneable, IComparable<Customer>
{
    private string firstName, middleName, lastName, id, address, phone, email;
    private IList<Payment> payments;
    private CustomerType customerType;

    public Customer(
        string firstName,
        string middleName,
        string lastName,
        string id,
        string address,
        string phone,
        string email,
        IList<Payment> payments,
        CustomerType customerType)
    {
        this.FirstName = firstName;
        this.MiddleName = middleName;
        this.LastName = lastName;
        this.ID = id;
        this.PermanentAddress = address;
        this.Phone = phone;
        this.Email = email;
        this.Payments = payments;
        this.CustomerType = customerType;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("First Name cannot be null or empty");
            }
            else
            {
                this.firstName = value;
            }
        }
    }

    public string MiddleName
    {
        get
        {
            return this.middleName;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Middle Name cannot be null or empty");
            }
            else
            {
                this.middleName = value;
            }
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Last Name cannot be null or empty");
            }
            else
            {
                this.lastName = value;
            }
        }
    }

    public string ID
    {
        get
        {
            return this.id;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("ID(EGN) cannot be null or empty");
            }
            else
            {
                this.id = value;
            }
        }
    }

    public string PermanentAddress
    {
        get
        {
            return this.address;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Permanent Address cannot be null or empty");
            }
            else
            {
                this.address = value;
            }
        }
    }

    public string Phone
    {
        get
        {
            return this.phone;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Phone cannot be null or empty");
            }
            else
            {
                this.phone = value;
            }
        }
    }

    public string Email
    {
        get
        {
            return this.email;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Email cannot be null or empty");
            }
            else
            {
                this.email = value;
            }
        }
    }

    public IList<Payment> Payments
    {
        get
        {
            return this.payments;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("List of Payments cannot be null");
            }
            else
            {
                this.payments = value;
            }
        }
    }

    public CustomerType CustomerType
    {
        get
        {
            return this.customerType;
        }
        set
        {
            this.customerType = value;
        }
    }

    public override bool Equals(object param)
    {
        // If the cast is invalid, the result will be null
        Customer customer = param as Customer;

        // Check if we have valid not null Customer object
        if (customer == null)
        {
            return false;
        }

        if (!Object.Equals(this.FirstName, customer.FirstName))
        {
            return false;
        }

        if (!Object.Equals(this.MiddleName, customer.MiddleName))
        {
            return false;
        }

        if (!Object.Equals(this.LastName, customer.LastName))
        {
            return false;
        }

        if (!Object.Equals(this.ID, customer.ID))
        {
            return false;
        }

        if (!Object.Equals(this.PermanentAddress, customer.PermanentAddress))
        {
            return false;
        }

        if (!Object.Equals(this.Phone, customer.Phone))
        {
            return false;
        }

        if (!Object.Equals(this.Email, customer.Email))
        {
            return false;
        }

        if (!(this.Payments.All(customer.Payments.Contains)))
        {
            return false;
        }

        if (this.CustomerType != customer.CustomerType)
        {
            return false;
        }

        return true;
    }

    public static bool operator ==(Customer customer1, Customer customer2)
    {
        return Customer.Equals(customer1, customer2);
    }

    public static bool operator !=(Customer customer1, Customer customer2)
    {
        return !(Customer.Equals(customer1, customer2));
    }

    public override int GetHashCode()
    {
        return
            FirstName.GetHashCode() ^
            MiddleName.GetHashCode() ^
            LastName.GetHashCode() ^
            ID.GetHashCode() ^
            PermanentAddress.GetHashCode() ^
            Phone.GetHashCode() ^
            Email.GetHashCode() ^
            Payments.GetHashCode() ^
            CustomerType.GetHashCode();
    }

    public override string ToString()
    {
        string customer =
            string.Format("Name: {0} {1} {2}\nID(EGN): {3}\nPermanents Address: {4}\nPhone: {5}\nEmail: {6}\nPayments:\n{7}\nCustomer Type: {8}\n",
            this.FirstName, this.MiddleName, this.LastName, this.ID, this.PermanentAddress, this.Phone, this.Email, string.Join("\n", this.Payments), this.CustomerType);

        return customer;
    }

    public object Clone()
    {
        return new Customer(this.FirstName, 
            this.MiddleName, this.LastName, 
            this.ID, this.PermanentAddress, 
            this.Phone, 
            this.Email, 
            new List<Payment>(this.Payments), 
            this.CustomerType);
    }

    public int CompareTo(Customer other)
    {
        var thisCustomer = string.Format("{0} {1} {2}", this.FirstName, this.MiddleName, this.LastName);
        var otherCustomer = string.Format("{0} {1} {2}", other.FirstName, other.MiddleName, other.LastName);

        var result = thisCustomer.CompareTo(otherCustomer);
        if (result == 0)
        {
            result = this.ID.CompareTo(other.ID);
        }

        return result;
    }
}
