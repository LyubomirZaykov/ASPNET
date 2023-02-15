using Microsoft.Extensions.Primitives;
using System.ComponentModel.Design.Serialization;
using System.IO;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    int firstNum = 0;
    int secondNum = 0;
    string typeOfOperation = null;
    int result = 0;
    bool isFirstNumOk = false;
    bool isSecondNumOk = false;
    if (context.Request.Query.ContainsKey("firstNumber"))
    {
        isFirstNumOk = int.TryParse(context.Request.Query["firstName"], out firstNum);
    }
    if (context.Request.Query.ContainsKey("secondNumber"))
    {
        isSecondNumOk = int.TryParse(context.Request.Query["secondNum"], out secondNum);
    }
    if (context.Request.Query.ContainsKey("operation"))
    {
        typeOfOperation = context.Request.Query["operation"];
    }
    bool isOperationOk = false;
    if (isFirstNumOk && isSecondNumOk)
    {
        switch (typeOfOperation)
        {
            case "add":
                isOperationOk = true;
                result = firstNum + secondNum;
                break;
            case "substract":
                isOperationOk = true;
                result = firstNum + secondNum;
                break;
            case "multiply":
                isOperationOk = true;
                result = firstNum * secondNum;
                break;
            case "divide":
                isOperationOk = true;
                result = firstNum / secondNum;
                break;
            case "mod":
                isOperationOk = true;
                result = firstNum % secondNum;
                break;
            default:
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid input for 'operation'\n");
                break;
        }
    }
    if (!isFirstNumOk||!isSecondNumOk)
    {
        if (!isFirstNumOk)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid input for 'firstNumber'\n");
        }
        if (!isSecondNumOk)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid input for 'secondNumber'\n");
        }
    }
    if (isFirstNumOk&&isSecondNumOk&&isOperationOk)
    {
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync($"{result}");

    }
});
app.Run();
