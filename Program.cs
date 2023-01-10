using ask;

var inputHandler = new InputHandler();

try
{
    await inputHandler.Handle(args);
}
catch (ExceptionBase ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.ErrorMassage);
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex);
}
finally
{
    Console.ResetColor();
}