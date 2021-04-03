using System.ComponentModel;

namespace Desk.Domain.Enums
{
    public enum AuthRole
    {
        [Description("Администратор")]
        Admin = 0,
        [Description("Гость")]
        Guest = 1
    }
}
