# FileSignaturePolicy

An extension that checks the signatures of files uploaded to your applications

# Usage

bool result = stream.Allow(FileTypes.Png, FileTypes.Pdf, FileTypes.Jpg_Jpeg);

or

bool result = byteArray.Allow(FileTypes.Png, FileTypes.Pdf);
