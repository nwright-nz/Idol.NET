# Idol.NET

A .NET client library for the HP IDOL OnDemand API's.
Work very much in progress, and at present only synchronous calls will work. Async coming...

You will need an API key for IDOL OnDemand - get one here : https://www.idolondemand.com/signup.html
See this post for more info on creating your key: https://nwrightnz.wordpress.com/2015/07/08/hello-world/

To use, first add a config file to your application. Add the following sections (substituting your api key in the field below)

```
<appSettings>
    <add key="BaseUrl" value="https://api.idolondemand.com/1/api"/>
    <add key="ApiKey" value =  "TOCOMPLETE"/>
  </appSettings>

```


follow the code snippet below:

```
using IDOLOnDemand.Model;
using IDOLOnDemand.Response;
using IDOLOnDemand.Helpers;

string text = "This is a good message to test the sentiment analysis engine with. I hope it works.";
            SentimentAnalysis analysis = new SentimentAnalysis()
            {
                Text = text ,
                Language = SentimentAnalysis.LanguageSelection.Eng
            };
            var response = analysis.Response();

            Console.WriteLine("The string '" + text + "'  had a " +  response.aggregate.sentiment + " sentiment. Its scoring was : " + response.aggregate.score);
            Console.ReadLine();
```

The pattern for the other API calls is the same.
Create the model (in this case sentiment analysis) , add the required parameters (see https://www.idolondemand.com/developer/apis for more info), then call the Response method.
This returns JSON that has been deserialized into objects for ease of use.

At present, these functions have been completed:

Expand Container : 	Extracts the contents of a container file.

OCR Document :	Extracts text from an image.

Store Object :	Stores a file.

Text Extraction :	Extracts text from a file.

View Document : 	Converts a document to HTML format for viewing in a Web browser.

Barcode Recognition : 	Detects and decodes 1D and 2D barcodes in an image that you provide.

Face Detection :	Detects faces in an image.

Image Recognition :	Recognizes a known set of images in an image that you provide.

Query Text Index :	Searches for items that match your specified natural language text, Boolean expressions, or fields.

Sentiment Analysis :	Analyzes text for positive or negative sentiment.

Add to Text Index: 	Indexes a document.

Create Text Index :	Creates a text index.

Add Store :	Adds a user store.

Add User :	Adds a user to an existing user store

Add User Role: Add a user role

Assign User To Store : Assign a user to an existing user role

Authenticate User : Authenticates a user

List User Roles : Lists all user roles



To get further info on any of these, please see https://www.idolondemand.com/developer/apis

Further API calls will be added gradually.
