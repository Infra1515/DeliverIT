namespace DeliverIT
{
    using DeliverIT.Common;
    /// <todo>
    /// 1. Implement Person behaviour
    /// 
    /// </todo>
    public abstract class Person
    {
        private string name;
        private string email;
        private int phoneNumber;
        private int years;
        private Country country;
        private GenderType gender;

        void ShowCurrentAddress()
        {
            //method showing curr address
        }

        void ShowInfo()
        {
            //method for showing information about curr person
        }
    }
}
