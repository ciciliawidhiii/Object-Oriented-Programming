using System;
using System.Collections.Generic;
using System.Text;

namespace Camera_Rental_Management
{
    class Rental
    {
        //Data Member 
        private int RegNo;
        private String Merk;
        private String Model;
        private Double Price;

        //Accessor function

        public int theRegNo
        {
            get
            {
                return this.RegNo;
            }
            set
            {
                this.RegNo = value;
            }
        }
        public String theMerk
        {
            get
            {
                return this.Merk;
            }
            set
            {
                this.Merk = value;
            }
        }
        public String theModel
        {
            get
            {
                return this.Model;
            }
            set
            {
                this.Model = value;
            }
        }
        public Double thePrice
        {
            get
            {
                return this.Price;
            }
            set
            {
                this.Price = value;
            }
        }
    }
}

class uCustomer
{
    //Member Identitiy 
    private int CustId;
    private String CustName;
    private String CustAdd;
    private int CustPhone;

    //Accessor Function 
    public int theCustId
    {
        get
        {
            return this.CustId;
        }
        set
        {
            this.CustId = value;
        }
    }
    public String theCustName
    {
        get
        {
            return this.CustName;
        }
        set
        {
            this.CustName = value;
        }
    }
    public String theCustAdd
    {
        get
        {
            return this.CustAdd;
        }
        set
        {
            this.CustAdd = value;
        }
    }
    public int theCustPhone
    {
        get
        {
            return this.CustPhone;
        }
        set
        {
            this.CustPhone = value;
        }
    }
}

class uRent
{
    //variable 
    private Double RentDate;
    private Double ReturnDate;
    private int RentFee;
    private int Days;

    public Double theRentDate
    {
        get
        {
            return this.RentDate;
        }
        set
        {
            this.RentDate = value;
        }
    }
    public Double theReturnDate
    {
        get
        {
            return this.ReturnDate;
        }
        set
        {
            this.ReturnDate = value;
        }
    }
    public int theRentFee
    {
        get
        {
            return this.RentFee;
        }
        set
        {
            this.RentFee = value;
        }
    }
    public int theDays
    {
        get
        {
            return this.Days;
        }
        set
        {
            this.Days = value;
        }
    }
}