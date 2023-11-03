namespace FileModifier;

public static class EventHandler
{
    private static InternalCode? statusCode = null;

    public static void LoadFile(object sender, EventArgs args)
    {
        statusCode = new InternalCode(Application.OpenForms[0].Controls["pathFile"].Text);
    }

    public static void ModifyFile(object sender, EventArgs args)
    {
        if (statusCode != null && statusCode.GetPath() != null)
        {
            statusCode.ModifyFile(((Button) sender).Name, Application.OpenForms[0].Controls["appendText"].Text);
        }
        else WindowDialog.showDialog("Error - Not selected", "./src/img/error.ico", "Please, select a file");
    }
}