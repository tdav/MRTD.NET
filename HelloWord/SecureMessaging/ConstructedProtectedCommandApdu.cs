﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;
using PCSC.Iso7816;

namespace HelloWord.SecureMessaging
{
    public class ConstructedProtectedCommandApdu : IBinary
    {
        private readonly IBinary _maskedCommandApduHeader;
        private readonly IBinary _do87or97;
        private readonly IBinary _do8e;
        private readonly byte[] _exceptedDataLength = new byte[] { 0x00 };

        public ConstructedProtectedCommandApdu(
              IBinary rawCommandApduHeader,
              IBinary do87or97,
              IBinary do8e
          )
        {
            _maskedCommandApduHeader = rawCommandApduHeader;
            _do87or97 = do87or97;
            _do8e = do8e;
        }
        public byte[] Bytes()
        {
            var commandData = new ProtectedCommandApduData(
                                    _do87or97,
                                    _do8e
                                );
            var commandDataLengthAsBinaryHex = new HexInt(
                                                    commandData
                                                        .Bytes()
                                                        .Count()
                                               );
            return new ConcatenatedBinaries(
                    _maskedCommandApduHeader,
                    commandDataLengthAsBinaryHex,
                    commandData,
                    new Binary(_exceptedDataLength)
                ).Bytes();
        }
    }
}
