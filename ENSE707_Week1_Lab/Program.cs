// SOFTWARE QUALITY ASSURANCE
// WEEK 1 LAB

/*

Activity 1:
1) Regular commiting means the commit sizes are smaller making it easier to track and find out what might potentially be causing the bugs.
2) Git history keeps track of which user commits so you can find out individual progress.

ACtivity 3:
1) An error should throw and ask the user to input a valid amount.
2) ^
3) ^
4) No, the fee calculation code doesn't explain why it's using that number
5) To test the class you have to manually write code in program.cs for everything you want to do, which is not that easy. It also doesn't have any error checks so
you will have to rely on visual studios error messages.
6) Deposits aren't recorded, it doesn't prevent users withdrwaing more money than allowed, doesn't handle invalid transactions.
7) Security, the program isn't secure as users can input any number they want.

Activity 4:
QA vs QC - Quality assurance means preventing bugs and errors through code before they happen. Quality control means observing output and correcting any bugs or errors that appear.

1) QA - Coding standards help with QA by ensuring your code matches a certified standard that doesn't produce errors.
2) QC - Running tests is a way to see what errors your program will produce.
3) QA - By reviewing requirements for ambiguity you make sure that you're clear on what the requirements are, or can ask your client for more detail.
4) QC - Running tests is a way to see what errors your program will produce.
5) QC - This is QC because you are running your code and correcting errors rather than preventing them in the first place.
6) QC - If you have failed test cases that means you didn't prevent the error first.
7) QA - This ensures that you already have valid financial rules rather than waiting for errors to appear.
8) QC

Discussion Question:
Because you can only test what you can think might go wrong, but you never know how a user will use your program and might produce errors you didn't think of.

*/

using ENSE707_Week1_Lab;

BankAccount account = new BankAccount("Student User", 100);

account.Deposit(50);
account.Withdraw(30);

Console.WriteLine($"Account holder: {account.AccountHolder}");
Console.WriteLine($"Current balance: {account.Balance}");
Console.WriteLine($"Fee on $100 transaction: {account.CalculateTransactionFree(100)}");