using PetaPoco;

namespace EcommerceMvc.Helper
{
    public interface ISaveToDatabase
    {
        void Save(object obj);

        ITransaction GetTraction();
        void Update(object obj);
    }
}