namespace HotelProject.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {   //Businesstaki ismi DataAccessten ayırabilmek için başına T koyduk.
        void TInsert(T t);
        void TDelete(T t);
        void TUpdate(T t);
        List<T> TGetList();
        T TGetByID(int id);
    }
}
