using System.Text;
using System.Net;
using System.Text.RegularExpressions;

namespace FileModifier;

public class InternalCode
{
    private string? urlFile = null;
    private static readonly HttpClient client = new HttpClient();

    public InternalCode(string pathFile)
    {

        try
        {
            checkWebURL(pathFile);
        }
        catch (Exception)
        {
            if (File.Exists(pathFile))
            {
                this.urlFile = pathFile;
                this.ReadFile();
            }
            else
            {

                Thread openThread = new(new ThreadStart(() =>
                {
                    try
                    {
                        using (FileStream fs = File.Create(pathFile)) ;
                    }
                    catch (Exception error)
                    {
                        WindowDialog.showDialog("Error - Creating File", "./src/img/error.ico", "Error while creating file - " + error.Message.ToString());
                    }
                }))
                {
                    Name = "FileModifier - FileCreation",
                    Priority = ThreadPriority.Highest
                };

                Application.OpenForms[0].Controls.OfType<Button>().ToList().ForEach((Button item) =>
                {
                    item.Enabled = false;
                });

                Thread.Sleep(1000);
                openThread.Start();
                openThread.Join();

                Application.OpenForms[0].Controls.OfType<Button>().ToList().ForEach((Button item) =>
                {
                    item.Enabled = true;
                });

                this.urlFile = pathFile;
            }
        }
    }

    public void ReadFile()
    {
        string text = "";
        int status = 0;
        string errorThread = "";

        Thread openThread = new Thread(new ThreadStart(() =>
        {
            try
            {
                text = File.ReadAllText(urlFile, Encoding.UTF8);
            }
            catch (Exception error)
            {
                status = 1;
                errorThread = error.Message.ToString();
            }
        }))
        {
            Priority = ThreadPriority.Highest,
            Name = "FileModifier - FileCreation",
        };

        openThread.Start();
        openThread.Join();

        if (status == 0) WindowDialog.showDialog("Result - Reading File", "./src/img/icon.ico", text);
        else WindowDialog.showDialog("Error - Creating File", "./src/img/error.ico", "Error while creating file - " + errorThread);
    }

    public void ModifyFile(string typeEvent, string contents)
    {
        int status = 0;
        string errorThread = "";

        Thread openThread = new Thread(new ThreadStart(() =>
        {
            try
            {
                if (typeEvent.Equals("write_button")) File.WriteAllText(urlFile, contents + "\n");
                else File.AppendAllText(urlFile, contents + "\n");
            }
            catch (Exception error)
            {
                status = 1;
                errorThread = error.Message.ToString();
            }
        }))
        {
            Priority = ThreadPriority.Highest,
            Name = "FileModifier - " + typeEvent,
        };

        openThread.Start();
        openThread.Join();

        if (status == 0) WindowDialog.showDialog("Result - " + openThread.Name, "./src/img/icon.ico", "Modification succesfully finished");
        else WindowDialog.showDialog("Error - " + openThread.Name, "./src/img/error.ico", "Error modifying file - " + errorThread);
    }

    public string? GetPath()
    {
        return this.urlFile;
    }

    private async void checkWebURL(string pathFile)
    {
        string urlTextSanitized = pathFile.Trim();
        Uri? urlChecked;

        if (Uri.TryCreate(urlTextSanitized, UriKind.Absolute, out urlChecked) && (urlChecked.Scheme == Uri.UriSchemeHttps))
        {
            string text = await client.GetStringAsync(urlChecked);

            WindowDialog.showDialog("Result - WebCalling Information", "./src/img/icon.ico", Regex.Replace(text, "<.*?>", String.Empty));
        }
    }
}