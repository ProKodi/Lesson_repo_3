




public class Program{
    /// <summary>
    /// Проверяет, соответствует ли пароль заданным требованиям.
    /// </summary>
    /// <param name="pass"> Пароль для проверки. </param>
    /// <returns>
    /// rue -> valid
    /// </returns>
    public static bool IsValidPassword(string pass){
        if(pass.Length < 8) return false; 

        bool hasDigit = pass.Any(char.IsDigit);
        bool hasUpper = pass.Any(char.IsUpper);
        bool hasSpecial = pass.Any(ch => "!@#$%^&*()".Contains(ch));

        return hasDigit && hasUpper && hasSpecial;
    } 


    public static void Main(string[] args){
        /// ...
    }
}