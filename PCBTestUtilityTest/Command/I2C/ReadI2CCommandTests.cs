﻿/*
 * Copyright (C) 1994-2018 Microstar Electric Company Limited
 * 
 * All Rights Reserved.
 * 
 * LEGAL NOTICE: All information contained herein is, and 
 * remains the property of Microstar Electric Company Limited. 
 * The intellectual and technical concepts contained herein 
 * are proprietary to Microstar Electric Company Limited, and 
 * may be covered by patents, patents in process and are 
 * protected by the trade secret or copyright laws. Commercial 
 * use, or disclosure, or dissemination, or reproduction of 
 * the information contained in this file are strictly 
 * forbidden unless official specific written permissions are 
 * obtained from Microstar Electric Company Limited.
 */
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microstar.Production.Comms.PCB;
using Microstar.Production.PCBTest.Command;
using Microstar.Production.Comms;
using Microstar.Production.PCBTest.Properties;

namespace Microstar.Production.PCBTest.Tests
{
    /// <summary>
    /// 读I2C命令单元测试
    /// </summary>
    [TestClass()]
    public class ReadI2CCommandTests : UnitTestBase
    {
        /// <summary>
        /// 执行读I2C命令
        /// </summary>
        [TestMethod()]
        public void ExcuteTest()
        {
            using (var client = PcbTesterClient.Create(PortName, BaudRate))
            {
                client.Open();
               
                var command = new ReadI2CCommand();

                var parameter = new AddressCommandParameter(0xA4, 0x20, 0x10);
         

                CommandResult result =  command.Execute(client, parameter, null);

                Assert.AreEqual(result.Success, true);
                Assert.AreEqual(result.Data, "126A9B63142533126A9B6314253333");
            }
        }
    }
}