//======================================================================
//
//        Copyright (C) 2007-2008 三月软件工作室    
//        All rights reserved
//
//        filename :Class
//        description :
//
//        created by任天胜 at  06/07/2011 18:41:28
//        qq:625246906
//        network:www.rtswin.com
//======================================================================
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections ;
using System.Xml ;


namespace hotManager
{
    class xmlHepler
    {
        /// 打开一个xml文件
        /// <summary>
        /// 打开一个xml文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public XmlDocument GetDoc(string path)
        {
            XmlDocument xmldoc = null;
            try
            {
               
                
                {
                    xmldoc = new XmlDocument();
                    xmldoc.Load(path);
                }
                return xmldoc;
            }
            catch
            {
                return xmldoc;
            }

        }

        /// 创建XML文件
        /// <summary>
        /// 创建XML文件
        /// </summary>
        /// <param name="path">要创建XML文件的路径</param>
        /// <param name="xmltext">XML节点的内容</param>
        /// <returns>是否创建成功</returns>
        public XmlDocument CreateXML(string path, string rootName)
        {
            try
            {
                string directiory = System.IO.Path.GetDirectoryName(path);
                if (!System.IO.Directory.Exists(directiory))
                {
                    System.IO.Directory.CreateDirectory(directiory );
                }
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.CreateXmlDeclaration("1.0", "utf-8", "no");
                XmlNode node = xmldoc.CreateNode("element", rootName, "");
                xmldoc.AppendChild(node);
                xmldoc.Save(path);
                return xmldoc;
            }
            catch
            {
                return null;
            }
        }

        /// 返回节点的TEXT
        /// <summary>
        /// 返回节点的TEXT
        /// </summary>
        /// <param name="path"></param>
        /// <param name="selectNode">NODE的xmlPath</param>
        /// <returns>内容</returns>
        public string GetNodeText(XmlDocument xmldoc, string selectNode)
        {
            try
            {
                XmlNode xmlnode = xmldoc.SelectSingleNode(selectNode);
                return xmlnode.InnerText;
            }
            catch
            {
                return null;
            }
        }

        /// 添加一个节点
        /// <summary>
        /// 添加一个节点
        /// </summary>
        /// <param name="xmldoc"></param>
        /// <param name="xPath"></param>
        /// <param name="nodeName"></param>
        /// <param name="nodeText"></param>
        /// <returns></returns>
        public bool AddNode(XmlDocument xmldoc, string xPath, string nodeName)
        {
            try
            {
                XmlNode parentNode = xmldoc.SelectSingleNode(xPath);
                XmlNode newNode = xmldoc.CreateNode(XmlNodeType.Element, nodeName, "");
                
                parentNode.AppendChild(newNode);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 添加一个节点
        /// <summary>
        /// 添加一个节点
        /// </summary>
        /// <param name="xmldoc"></param>
        /// <param name="xPath"></param>
        /// <param name="nodeName"></param>
        /// <param name="nodeText"></param>
        /// <returns></returns>
        public bool AddNode(XmlDocument xmldoc, string xPath, string nodeName, string nodeText)
        {
            try
            {
                XmlNode parentNode = xmldoc.SelectSingleNode(xPath);
                XmlNode newNode = xmldoc.CreateNode(XmlNodeType.Element  , nodeName, "");
                if (nodeText.Trim() != "")
                    newNode.InnerText  =  nodeText ;
                parentNode.AppendChild(newNode);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 添加一个节点 ,带子节点
        /// <summary>
        /// 添加一个节点，带子节点
        /// </summary>
        /// <param name="xmldoc"></param>
        /// <param name="xPath"></param>
        /// <param name="nodeName"></param>
        /// <param name="nodeText"></param>
        /// <returns></returns>
        public bool AddNode(XmlDocument xmldoc, string xPath, string nodeName, ArrayList nodes,ArrayList text )
        {
            try
            {
                XmlNode parentNode = xmldoc.SelectSingleNode(xPath);
                XmlNode newNodeRoot = xmldoc.CreateNode(XmlNodeType.Element, nodeName, "");
                XmlNode newNode;
                for (int i = 0; i < nodes.Count; i++)
                {
                    newNode = xmldoc.CreateNode(XmlNodeType.Element, nodes[i].ToString (), "");
                    if (text[i].ToString ().Trim() != "")
                        newNode.InnerText =  text[i].ToString () ;
                    newNodeRoot.AppendChild(newNode);
                }
                parentNode.AppendChild(newNodeRoot);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 修改指定的节点
        /// </summary>
        /// <param name="xmldoc"></param>
        /// <param name="xPath">到于指定节点的</param>
        /// <param name="nodeName"></param>
        /// <param name="newText"></param>
        /// <returns></returns>
        public bool EditNode(XmlDocument xmldoc, string xPath,string nodeName, string newText)
        {
            try
            {
                XmlNode node = xmldoc.SelectSingleNode(xPath);
                node.SelectSingleNode (nodeName ).InnerText  = newText;
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="xmldoc"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool SaveXml(XmlDocument xmldoc, string path)
        {
            try
            {
                xmldoc.Save(path);
                xmldoc = null;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="xmldoc"></param>
        /// <param name="XPath"></param>
        /// <returns></returns>
        public bool DeleteNode(XmlDocument xmldoc, string XPath)
        {
            XmlNode node = xmldoc.SelectSingleNode(XPath);
            node.ParentNode.RemoveChild(node);
            return true;
        }

    }

    class WriteData : xmlHepler
    {
       public   string path = "";

        public bool AddRecord(string appName, string appPath, string keys,string guid,string index)
        {
            XmlDocument xmldoc = GetDoc(path);
            if (xmldoc != null)
            {
                ArrayList node = new ArrayList();
                ArrayList text = new ArrayList();
                node.Add("name");
                node.Add("path");
                node.Add("keys");
                node.Add("guid");
                node.Add("location");
                text.Add(appName);
                text.Add(appPath);
                text.Add(keys);
                text.Add(guid);
                text.Add(index );
                AddNode(xmldoc, "root", "appliction",node,text );
                xmldoc.Save(path);
                return true;
            }
            return false;
        }

        public bool EditRecord(string appName, string appPath, string keys, string guid)
        {
            XmlDocument xmldoc = GetDoc(path);
            string xPath = "root/appliction[guid='" + guid + "']";
            EditNode(xmldoc, xPath, "name", appName);
            EditNode(xmldoc, xPath, "path", appPath);
            EditNode(xmldoc, xPath, "keys", keys);
            xmldoc.Save(path);
            return true;
        }

        public bool DeleteRecord(string guid)
        {
            XmlDocument xmldoc = GetDoc(path );
            string XPath = "root/appliction[guid='"+guid+"']";
            DeleteNode(xmldoc,XPath );
            xmldoc.Save(path );
            return true;
        }

        public bool CreateFile()
        {
            CreateXML(path,"root");
            return true;
        }

        public string GetNodeText(string XPath)
        {
            XmlDocument xmldoc = GetDoc(path);
           return GetNodeText(xmldoc ,XPath );
        }

        public bool EditClock(string name, string time, string week, string guid,string msg)
        {
            XmlDocument xmldoc = GetDoc(path);
            if (xmldoc != null)
            {
                if ("" == guid)
                {
                    ArrayList node = new ArrayList();
                    ArrayList text = new ArrayList();
                    guid = Guid.NewGuid().ToString();
                    node.Add("guid");
                    node.Add("name");
                    node.Add("time");
                    node.Add("week");
                    node.Add("msg");
                    text.Add(name);
                    text.Add(name);
                    text.Add(time);
                    text.Add(week);
                    text.Add(msg);
                    AddNode(xmldoc, "root", "clock", node, text);
                }
                else
                {
                    string xPath = "root/clock[guid='" + guid + "']";
                    EditNode(xmldoc, xPath, "name", name);
                    EditNode(xmldoc, xPath, "time", time);
                    EditNode(xmldoc, xPath, "week", week);
                }
                xmldoc.Save(path);
                return true;
            }
            
            return true;
        }
       
    }
}
