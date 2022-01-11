using System;
namespace OsaGadgetStore
{
    public interface IConn
    {
        List<Account> GetUserInfo(string name);
    }
}

