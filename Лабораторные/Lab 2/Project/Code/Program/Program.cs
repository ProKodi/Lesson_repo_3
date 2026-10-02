



public static class Program {
    public static bool ValidateAge(int age) {
        if (age < 18 || age > 65)
            throw new ArgumentException("Возраст должен быть от 18 до 65 лет.");

        return true;
    }

    public static bool ValidateEmail(string email) {
        if ( string.IsNullOrEmpty(email) || email.Length < 5 || !email.Contains('@') || !email.Contains('.') )
            throw new ArgumentException("Некорректный email.");

        return true;
    }


    public static void Main(string[] args){
        
    }
}