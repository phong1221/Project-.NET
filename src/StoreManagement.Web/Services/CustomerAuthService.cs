using StoreManagement.Data.Entities;

namespace StoreManagement.Web.Services
{
    public class CustomerAuthService
    {
        public Customer? CurrentCustomer { get; private set; }
        public event Action OnChange;
        
        public bool IsLoggedIn => CurrentCustomer != null;

        public void Login(Customer customer)
        {
            CurrentCustomer = customer;
            NotifyStateChanged();
        }

        public void Logout()
        {
            CurrentCustomer = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
