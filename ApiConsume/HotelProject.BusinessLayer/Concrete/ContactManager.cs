using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactdal;

        public ContactManager(IContactDal contactdal)
        {
            _contactdal = contactdal;
        }

        public void TDelete(Contact t)
        {
            _contactdal.Delete(t);
        }

        public Contact TGetByID(int id)
        {
            return _contactdal.GetByID(id);
        }

        public List<Contact> TGetList()
        {
            return _contactdal.GetList();
        }

        public void TInsert(Contact t)
        {
            _contactdal.Insert(t);
        }

        public void TUpdate(Contact t)
        {
            _contactdal.Update(t);
        }
    }
}
