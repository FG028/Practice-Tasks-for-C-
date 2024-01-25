Using system;

Namespace practice01 {
    Public Class program {
        Public Static void main(){

            String name;
            int age;
            String email;
            int password;

            console.write("please enter your name: ");

            name = console.readline();

            console.write("please enter your age: ");

            age = convert.toint32(console.readline());

            console.write("please enter your e.mail address: " );
            
            email = console.readline();

            console.write("what is your password?: ");

            password = convert.toint32(console.readline());

            console.writeline();

            console.writeline("your name is {0}.", name);

            console.writeline("your age is {0}.", age);
            
            console.writeline("your e-mail address is {0}.", email);

            console.writeline("your password is {0}.", password);
        }
        Public Static clear();
    }
    End Class
}
End Namespace