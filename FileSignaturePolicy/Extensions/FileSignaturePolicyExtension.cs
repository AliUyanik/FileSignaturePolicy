using FileSignaturePolicy.Base;
using FileSignaturePolicy.Enums;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace FileSignaturePolicy.Extensions
{
    public static class FileSignaturePolicyExtension
    {
        public static bool Allow(this Stream stream, params FileTypes[] AllowTypes)
        {
            FilePolicyController SignatureService = new FilePolicyController();
            bool isAllowed = false;
            if (stream.CanRead)
            {
                foreach (FileTypes ftype in AllowTypes.Distinct())
                {
                    switch (ftype)
                    {
                        case FileTypes.Pdf:
                            isAllowed |= SignatureService.IsPdf(StreamHelper.GetBytes(stream, 0, 5, 8));
                            break;
                        case FileTypes.Office:
                            isAllowed |= SignatureService.IsOffice(StreamHelper.GetBytes(stream, 0, 8, 8));
                            isAllowed |= SignatureService.IsNewOffice(StreamHelper.GetBytes(stream, 0, 4, 4));
                            break;
                        case FileTypes.Png:
                            isAllowed |= SignatureService.IsPng(StreamHelper.GetBytes(stream, 0, 8, 8));
                            break;
                        case FileTypes.Jpg_Jpeg:
                            isAllowed |= SignatureService.IsJpgPart1(StreamHelper.GetBytes(stream, 0, 4, 4));
                            isAllowed |= SignatureService.IsJpgPart2(StreamHelper.GetBytes(stream, 0,12, 12));
                            break;
                        case FileTypes.Gif:
                            isAllowed |= SignatureService.IsGif(StreamHelper.GetBytes(stream, 0, 6, 8));
                            break;
                        case FileTypes.Tif:
                            isAllowed |= SignatureService.IsTiff(StreamHelper.GetBytes(stream, 0, 4, 4));
                            break;
                        case FileTypes.Mpg_Mpeg:
                            isAllowed |= SignatureService.IsMpeg(StreamHelper.GetBytes(stream, 0, 4, 4));
                            break;
                        case FileTypes.Ttf:
                            isAllowed |= SignatureService.IsTtf(StreamHelper.GetBytes(stream, 0, 5, 8));
                            break;
                        case FileTypes.Flv:
                            isAllowed |= SignatureService.IsFlv(StreamHelper.GetBytes(stream, 0, 3, 4));
                            break;
                        case FileTypes.Mp4:
                            isAllowed |= SignatureService.IsMp4(StreamHelper.GetBytes(stream, 4, 8, 8));
                            break;
                        case FileTypes.Dcm:
                            isAllowed |= SignatureService.IsDcm(StreamHelper.GetBytes(stream, 0, 4, 4));
                            break;
                        case FileTypes.Psd:
                            isAllowed |= SignatureService.IsPsd(StreamHelper.GetBytes(stream, 0, 4, 4));
                            break;
                        default:
                            break;
                    }
                    if (isAllowed)
                    {
                        break;
                    }
                }
            }
            else return false;
            return isAllowed;
        }

        public static bool Allow(this byte[] source, params FileTypes[] AllowTypes)
        {
            FilePolicyController SignatureService = new FilePolicyController();
            bool isAllowed = false;
            if (source.Length > 0)
            {
                foreach (FileTypes ftype in AllowTypes.Distinct())
                {
                    switch (ftype)
                    {
                        case FileTypes.Pdf:
                            isAllowed |= SignatureService.IsPdf(ByteHelper.Copy(source, 0, 5, 8));
                            break;
                        case FileTypes.Office:
                            isAllowed |= SignatureService.IsOffice(ByteHelper.Copy(source, 0, 8, 8));
                            isAllowed |= SignatureService.IsNewOffice(ByteHelper.Copy(source, 0, 4, 4));
                            break;
                        case FileTypes.Png:
                            isAllowed |= SignatureService.IsPng(ByteHelper.Copy(source, 0, 8, 8));
                            break;
                        case FileTypes.Jpg_Jpeg:
                            isAllowed |= SignatureService.IsJpgPart1(ByteHelper.Copy(source, 0, 4, 4));
                            isAllowed |= SignatureService.IsJpgPart2(ByteHelper.Copy(source, 0, 12, 12));
                            break;
                        case FileTypes.Gif:
                            isAllowed |= SignatureService.IsGif(ByteHelper.Copy(source, 0, 6, 8));
                            break;
                        case FileTypes.Tif:
                            isAllowed |= SignatureService.IsTiff(ByteHelper.Copy(source, 0, 4, 4));
                            break;
                        case FileTypes.Mpg_Mpeg:
                            isAllowed |= SignatureService.IsMpeg(ByteHelper.Copy(source, 0, 4, 4));
                            break;
                        case FileTypes.Ttf:
                            isAllowed |= SignatureService.IsTtf(ByteHelper.Copy(source, 0, 5, 8));
                            break;
                        case FileTypes.Flv:
                            isAllowed |= SignatureService.IsFlv(ByteHelper.Copy(source, 0, 3, 4));
                            break;
                        case FileTypes.Mp4:
                            isAllowed |= SignatureService.IsMp4(ByteHelper.Copy(source, 4, 8, 8));
                            break;
                        case FileTypes.Dcm:
                            isAllowed |= SignatureService.IsDcm(ByteHelper.Copy(source, 0, 4, 4));
                            break;
                        case FileTypes.Psd:
                            isAllowed |= SignatureService.IsPsd(ByteHelper.Copy(source, 0, 4, 4));
                            break;
                        default:
                            break;
                    }
                    if (isAllowed)
                    {
                        break;
                    }
                }
            }
            else return false;
            return isAllowed;
        }
    }
}
