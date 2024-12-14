namespace Itmo.ObjectOrientedProgramming.Lab5.DomainLayer;

public static class Admin
{
    private static string _hashedPassword = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5";

    public static bool IsPassword(string password)
    {
        return _hashedPassword == password;
    }

    public static void ChangePassword(string hashedNewPassword)
    {
        _hashedPassword = hashedNewPassword;
    }
}