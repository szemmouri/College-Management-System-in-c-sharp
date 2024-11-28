using CMSDataLayer;
using System;


namespace CMSBusinessLayer
{
    public class clsPeople
    {
        public int PersonID {  get; set; }
        public string FirstName {  get; set; }
        public string LastName {  get; set; }
        public byte Gender {  get; set; }
        public DateTime DateOfBirth {  get; set; }
        public string PhoneNumber {  get; set; }
        public string Email {  get; set; }
        public string Address {  get; set; }
        public string ImagePath {  get; set; }

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public clsPeople()
        {
            PersonID = -1;
            FirstName = "";
            LastName = "";
            Gender = 0;
            DateOfBirth = DateTime.MinValue;
            PhoneNumber = "";
            Email = "";
            Address = "";
            ImagePath = "";

            Mode = enMode.AddNew;
        }
        public clsPeople(int personID, string firstName, string lastName, byte gender, DateTime dateOfBirth, string email, string phoneNumber, string address, string imagePath)
        {
            PersonID = personID;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            ImagePath = imagePath;

            Mode = enMode.Update;
        }
    
        private bool _AddNewPerson()
        {
            this.PersonID = clsPeopleData.AddNewPerson(this.FirstName, this.LastName, this.Gender, this.DateOfBirth, this.Email, this.PhoneNumber, this.Address, this.ImagePath);

            return this.PersonID  != -1;
        }

        private bool _UpdatePerson()
        {
            return clsPeopleData.UpdatePerson(this.PersonID, this.FirstName, this.LastName, this.Gender, this.DateOfBirth, this.Email, this.PhoneNumber, this.Address, this.ImagePath);
        }

        public static clsPeople Find(int PersonID)
        {
            byte gender  = 0;
            DateTime dateOfBirth = DateTime.Now;
            string firstName = "", lastName = "", Email = "", phoneNumber = "", address = "" , imagePath = "";

            bool isFund = clsPeopleData.FindPersonByID(PersonID, ref firstName, ref lastName, ref gender,   ref dateOfBirth, ref Email, ref phoneNumber, ref address, ref imagePath);

            if (isFund)
                return new clsPeople(PersonID, firstName, lastName, gender, dateOfBirth, Email, phoneNumber, address, imagePath);
            else
                return null;
        }

        public static clsPeople FindPersonByUserRoleID(int UserRoleID)
        {
            byte gender = 0;
            DateTime dateOfBirth = DateTime.Now;
            string firstName = "", lastName = "", Email = "", phoneNumber = "", address = "", imagePath = "";
            int PersonID = -1;

            bool isFund = clsPeopleData.FindPersonByUserRoleID(UserRoleID, ref PersonID, ref firstName, ref lastName, ref gender, ref dateOfBirth, ref Email, ref phoneNumber, ref address, ref imagePath);

            if (isFund)
                return new clsPeople(PersonID, firstName, lastName, gender, dateOfBirth, Email, phoneNumber, address, imagePath);
            else
                return null;
        }
        virtual public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePerson();
            }

            return false;
        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPeopleData.DeletePerson(PersonID);
        }

    }
}
