using System;
using System.Collections;

namespace FileSignaturePolicy.Base
{
    internal class FilePolicyController
    {
        public bool IsPdf(byte[] source) =>
            (BitConverter.ToUInt64(source) ^ 194452410405) == 0;

        public bool IsJpgPart1(byte[] source) =>
            (BitConverter.ToUInt32(source) ^ 3690977535) == 0 |
            (BitConverter.ToUInt32(source) ^ 4009744639) == 0 |
            (BitConverter.ToUInt32(source) ^ 3774863615) == 0 |
            (BitConverter.ToUInt32(source) ^ 1375686655) == 0;

        public bool IsJpgPart2(byte[] source) =>
            new BitArray(new byte[] { 0x00, 0x00, 0x00, 0x0C, 0x6A, 0x50, 0x20, 0x20, 0x0D, 0x0A, 0x87, 0x0A })
            .Xor(new BitArray(source)) == new BitArray(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }) |
            new BitArray(new byte[] { 0xFF, 0xD8, 0xFF, 0xE0, 0x00, 0x10, 0x4A, 0x46, 0x49, 0x46, 0x00, 0x01 })
            .Xor(new BitArray(source)) == new BitArray(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }) |
            new BitArray(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF })
            .And(new BitArray(source)).Xor(new BitArray(new byte[] { 0xFF, 0xD8, 0xFF, 0xE1, 0x00, 0x00, 0x45, 0x78, 0x69, 0x66, 0x00, 0x00 }))
            == new BitArray(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

        public bool IsOffice(byte[] source) =>
            (BitConverter.ToUInt64(source) ^ 16220472316735377360) == 0;

        public bool IsNewOffice(byte[] source) =>
            (BitConverter.ToUInt32(source) ^ 67324752) == 0;

        public bool IsPng(byte[] source) =>
            (BitConverter.ToUInt64(source) ^ 727905341920923785) == 0;

        public bool IsGif(byte[] source) =>
            (BitConverter.ToUInt64(source) ^ 944130375) == 0 |
            (BitConverter.ToUInt64(source) ^ 944130375) == 0;

        public bool IsTiff(byte[] source) =>
            (BitConverter.ToUInt32(source) ^ 2771273) == 0 |
            (BitConverter.ToUInt32(source) ^ 704662861) == 0;

        public bool IsMpeg(byte[] source) =>
            (BitConverter.ToUInt32(source) ^ 3120627712) == 0 |
            (BitConverter.ToUInt32(source) ^ 3003187200) == 0;

        public bool IsTtf(byte[] source) =>
            (BitConverter.ToUInt64(source) ^ 256) == 0;

        public bool IsFlv(byte[] source) =>
            (BitConverter.ToUInt32(source) ^ 5655622) == 0;

        public bool IsDcm(byte[] source) =>
            (BitConverter.ToUInt32(source) ^ 1296255300) == 0;

        public bool IsPsd(byte[] source) =>
            (BitConverter.ToUInt32(source) ^ 1397768760) == 0;

        public bool IsMp4(byte[] source) =>
            (BitConverter.ToUInt64(source) ^ 7885648369244796006) == 0 |
            (BitConverter.ToUInt64(source) ^ 6218999727509828710) == 0;

    }
}
