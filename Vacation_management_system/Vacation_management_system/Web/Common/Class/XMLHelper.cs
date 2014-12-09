using System;
using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.XPath;

    /// <summary>
    /// Summary description for XMLHelper.
    /// </summary>
    public class XmlHelper
    {
       
        #region Public Methods

        /// <summary>
        /// Gets an Xml document
        /// </summary>
        /// <param name="fileName">Xml file name</param>
        /// <returns>XmlDocument if the file exists else null</returns>
        public static XmlDocument GetXmlDocument(string fileName)
        {
            if (!File.Exists(fileName))
                return null;

            try
            {
                XmlDocument doc = new XmlDocument();

                doc.Load(fileName);

                return doc;
            }
            catch (XmlException ex)
            {
                //  WriteErrorLog(ex);
            }

            return null;
        }

        /// <summary>
        /// Gets an Xml document
        /// </summary>
        /// <param name="stream">Input stream</param>
        /// <returns>XmlDocument if the file exists else null</returns>
        public static XmlDocument GetXmlDocument(System.IO.Stream stream)
        {
            if (stream == null)
                return null;

            try
            {
                XmlDocument doc = new XmlDocument();

                doc.Load(stream);

                return doc;
            }
            catch (XmlException ex)
            {
                // //Logger.WriteErrorLog(ex);
            }

            return null;
        }

        /// <summary>
        /// Gets all nodes specified by xPath
        /// </summary>
        /// <param name="fileName">Xml file name</param>
        /// <param name="xpath">Path to traverse through the document to get table name</param>
        /// <returns>XmlNodeList if successful else null</returns>
        public static XmlNodeList GetXmlNodeList(string fileName, string xpath)
        {
            XmlDocument doc = GetXmlDocument(fileName);

            try
            {
                if (doc != null)
                    return doc.SelectNodes(xpath);
            }
            catch (XPathException ex)
            {
                // //Logger.WriteErrorLog(ex);

            }

            return null;
        }

        /// <summary>
        /// Gets all nodes specified by xPath
        /// </summary>
        /// <param name="xdoc">XmlDocument</param>
        /// <param name="xpath">Path to traverse through the document to get table name</param>
        /// <returns>XmlNodeList if successful else null</returns>
        public static XmlNodeList GetXmlNodeList(XmlDocument xdoc, string xpath)
        {
            try
            {
                if (xdoc != null)
                    return xdoc.SelectNodes(xpath);
            }
            catch (XPathException ex)
            {
                ////Logger.WriteErrorLog(ex);
            }
            return null;
        }

        /// <summary>
        /// Gets a node specified by the xpath
        /// </summary>
        /// <param name="xdoc">XmlDocument</param>
        /// <param name="xPath">Xpath to traverse through the document to get the node</param>
        /// <returns>XmlNode if successful else null</returns>
        public static XmlNode GetXMLNode(XmlDocument xdoc, string xPath)
        {
            try
            {
                if (xdoc != null)
                    return xdoc.SelectSingleNode(xPath);
            }
            catch (XPathException ex)
            {
                // //Logger.WriteErrorLog(ex);
            }
            return null;
        }

        /// <summary>
        /// Gets node list count
        /// </summary>
        /// <param name="xPath">Xpath to get nodelist</param>
        /// <param name="xdoc">XmlDocumnet</param>
        /// <returns>If successful nodes count else -1</returns>
        public static int GetNodeListCount(string xPath, XmlDocument xdoc)
        {
            try
            {
                XPathNavigator nav = xdoc.CreateNavigator();

                XPathNodeIterator nodes = nav.Select(xPath);

                return nodes.Count;
            }
            catch (XPathException ex)
            {
                // //Logger.WriteErrorLog(ex);
            }
            catch (ArgumentException ex)
            {
                // //Logger.WriteErrorLog(ex);
            }
            return -1;
        }

        /// <summary>
        /// Gets nodevalue of xml file
        /// </summary>
        /// <param name="fileName">XML file</param>
        /// <param name="xpath">Xpath to traverse till the node</param>
        /// <returns>Node value if sucessful else null</returns>
        public static string GetNodeValue(string fileName, string xpath)
        {
            XmlDocument doc = GetXmlDocument(fileName);
            try
            {
                if (doc != null)
                {
                    XPathNavigator nav = doc.CreateNavigator();

                    XPathNodeIterator nodeIterator = nav.Select(xpath);

                    nodeIterator.MoveNext();

                    return nodeIterator.Current.Value;
                }
            }
            catch (XPathException ex)
            {
                ////Logger.WriteErrorLog(ex);
            }
            catch (ArgumentException ex)
            {
                // //Logger.WriteErrorLog(ex);
            }

            return null;
        }

        /// <summary>
        /// Gets nodevalue of xml file
        /// </summary>
        /// <param name="doc">XmlDocument</param>
        /// <param name="xpath">Xpath to traverse till the node</param>
        /// <returns>Node value if sucessful else null</returns>
        public static string GetNodeValue(XmlDocument doc, string xpath)
        {
            try
            {
                if (doc != null)
                {
                    XPathNavigator nav = doc.CreateNavigator();

                    XPathNodeIterator nodeIterator = nav.Select(xpath);

                    nodeIterator.MoveNext();

                    return nodeIterator.Current.Value;
                }
            }
            catch (XPathException ex)
            {
                ////Logger.WriteErrorLog(ex);
            }
            catch (ArgumentException ex)
            {
                ////Logger.WriteErrorLog(ex);
            }

            return null;
        }

        /// <summary>
        /// Checks whether a node exists in the xPath
        /// </summary>
        /// <param name="xdoc">XmlDocument</param>
        /// <param name="nodeName">Node name to be checked</param>
        /// <returns>If node exists then returns xpath to the node else null</returns>
        public static string IsNodeExists(XmlDocument xdoc, string nodeName)
        {
            try
            {
                XmlElement root = xdoc.DocumentElement;

                XmlNodeReader reader = new XmlNodeReader(root);

                string xPath = string.Empty;
                bool isNodeExists = false;

                while (reader.Read())
                {
                    int index = xPath.IndexOf(reader.Name) - 1;

                    int lastIndex = xPath.LastIndexOf("/");

                    if (index > 0)
                    {
                        xPath = xPath.Remove(index, xPath.Length - index);
                    }
                    else
                    {
                        if (reader.Name != "")
                        {
                            xPath += "/" + reader.Name;
                        }
                        else
                        {
                            xPath = xPath.Remove(lastIndex, xPath.Length - lastIndex);

                            reader.Read();
                        }
                    }

                    if (reader.Name == nodeName)
                    {
                        isNodeExists = true;

                        break;
                    }
                }

                reader.Close();

                if (isNodeExists)
                {
                    return xPath;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                //Logger.WriteErrorLog(ex);
                return "";
            }
        }

        /// <summary>
        /// Creates an xml node with the specified name, attributes list and node value
        /// </summary>
        /// <param name="xdoc">XmlDocument</param>
        /// <param name="nodeName">Node name</param>
        /// <param name="attributesNameList">List of attribute names</param>
        /// <param name="attributesValueList">List of attribute values</param>
        /// <param name="nodeValue">Node value</param>
        /// <returns>XmlNode</returns>
        public static XmlNode CreateXMLNode(XmlDocument xdoc, string nodeName, ArrayList attributesNameList,
                                            ArrayList attributesValueList, string nodeValue)
        {
            try
            {
                XmlElement xmlElement = xdoc.CreateElement(nodeName);

                for (int i = 0; i < attributesNameList.Count; i++)
                {
                    xmlElement.SetAttribute((string) attributesNameList[i], (string) attributesValueList[i]);
                }

                attributesNameList.Clear();

                attributesValueList.Clear();

                xmlElement.InnerText = nodeValue;

                return xmlElement;
            }
            catch (Exception ex)
            {
                ////Logger.WriteErrorLog(ex);

                return null;
            }
        }

        /// <summary>
        /// Creates an xml node with the specified name, attributes list 
        /// </summary>
        /// <param name="xdoc">XmlDocument</param>
        /// <param name="nodeName">Node name</param>
        /// <param name="attributesNameList">List of attribute names</param>
        /// <param name="attributesValueList">List of attribute values</param>
        /// <returns>XmlNode if successful else null</returns>
        public static XmlNode CreateXMLNode(XmlDocument xdoc, string nodeName, ArrayList attributesNameList,
                                            ArrayList attributesValueList)
        {
            try
            {
                XmlElement xmlElement = xdoc.CreateElement(nodeName);

                for (int i = 0; i < attributesNameList.Count; i++)
                {
                    xmlElement.SetAttribute((string) attributesNameList[i], (string) attributesValueList[i]);
                }

                attributesNameList.Clear();

                attributesValueList.Clear();

                return xmlElement;
            }
            catch (Exception ex)
            {
                ////Logger.WriteErrorLog(ex);

                return null;
            }
        }

        /// <summary>
        /// Creates an xml node with the specified name, attributes list 
        /// </summary>
        /// <param name="xdoc">XmlDocument</param>
        /// <param name="nodeName">Node name</param>
        /// <param name="htAttributeNameValue">attribute names and its values hashtable</param>
        /// <param name="nodeValue">Node Value</param>
        /// <returns>XmlNode if successful else null</returns>
        public static XmlNode CreateXMLNode(XmlDocument xdoc, string nodeName, Hashtable htAttributeNameValue,
                                            string nodeValue)
        {
            try
            {
                XmlElement xmlElement = xdoc.CreateElement(nodeName);

                ArrayList attributesNameList = new ArrayList(htAttributeNameValue.Keys);

                for (int i = 0; i < attributesNameList.Count; i++)
                {
                    xmlElement.SetAttribute((string) attributesNameList[i],
                                            (string) htAttributeNameValue[attributesNameList[i]]);
                }

                attributesNameList.Clear();

                htAttributeNameValue.Clear();

                xmlElement.InnerText = nodeValue;

                return xmlElement;
            }
            catch (Exception ex)
            {
                ////Logger.WriteErrorLog(ex);

                return null;
            }
        }

        /// <summary>
        /// Creates an xml node with the specified name, attributes list 
        /// </summary>
        /// <param name="xdoc">XmlDocument</param>
        /// <param name="nodeName">Node name</param>
        /// <param name="htAttributeNameValue">attribute names and its values hashtable</param>
        /// <returns>XmlNode if successful else null</returns>
        public static XmlNode CreateXMLNode(XmlDocument xdoc, string nodeName, Hashtable htAttributeNameValue)
        {
            try
            {
                XmlElement xmlElement = xdoc.CreateElement(nodeName);

                ArrayList attributesNameList = new ArrayList(htAttributeNameValue.Keys);

                for (int i = 0; i < attributesNameList.Count; i++)
                {
                    xmlElement.SetAttribute((string) attributesNameList[i],
                                            (string) htAttributeNameValue[attributesNameList[i]]);
                }

                attributesNameList.Clear();

                htAttributeNameValue.Clear();

                return xmlElement;
            }
            catch (Exception ex)
            {
                ////Logger.WriteErrorLog(ex);

                return null;
            }
        }

        /// <summary>
        /// Creates an xml node with the specified name, attributes list 
        /// </summary>
        /// <param name="xdoc">XmlDocument</param>
        /// <param name="nodeName">Node name</param>
        /// <param name="attributeName">List of attribute names</param>
        /// <param name="attributeValue">List of attribute values</param>
        /// <param name="nodeValue">Node value to be set</param>
        /// <returns>XmlNode if successful else null</returns>
        public static XmlNode CreateXMLNode(XmlDocument xdoc, string nodeName, string attributeName,
                                            string attributeValue, string nodeValue)
        {
            try
            {
                XmlElement xmlElement = xdoc.CreateElement(nodeName);

                xmlElement.SetAttribute(attributeName, attributeValue);

                xmlElement.InnerText = nodeValue;

                return xmlElement;
            }
            catch (Exception ex)
            {
                ////Logger.WriteErrorLog(ex);

                return null;
            }
        }

        /// <summary>
        /// Creates an xml node with the specified name, attributes list 
        /// </summary>
        /// <param name="xdoc">XmlDocument</param>
        /// <param name="nodeName">Node name</param>
        /// <param name="attributeName">List of attribute names</param>
        /// <param name="attributeValue">List of attribute values</param>
        /// <returns>XmlNode if successful else null</returns>
        public static XmlNode CreateXMLNode(XmlDocument xdoc, string nodeName, string attributeName,
                                            string attributeValue)
        {
            try
            {
                XmlElement xmlElement = xdoc.CreateElement(nodeName);

                xmlElement.SetAttribute(attributeName, attributeValue);

                return xmlElement;
            }
            catch (Exception ex)
            {
                ////Logger.WriteErrorLog(ex);

                return null;
            }
        }

        /// <summary>
        /// Creates an xml node with the specified name and node value
        /// </summary>
        /// <param name="xdoc">XmlDocument</param>
        /// <param name="nodeName">Node name</param>
        /// <param name="nodeValue">Node value</param>
        /// <returns>XmlNode if sucessful else null</returns>
        public static XmlNode CreateXMLNode(XmlDocument xdoc, string nodeName, string nodeValue)
        {
            try
            {
                XmlElement xmlElement = xdoc.CreateElement(nodeName);

                xmlElement.InnerText = nodeValue;

                return xmlElement;
            }
            catch (Exception ex)
            {
                ////Logger.WriteErrorLog(ex);

                return null;
            }
        }

        /// <summary>
        /// Creates an xml node with the specified name and node value
        /// </summary>
        /// <param name="xdoc">XmlDocument</param>
        /// <param name="nodeName">Node name</param>
        /// <returns>XmlNode if sucessful else null</returns>
        public static XmlNode CreateXMLNode(XmlDocument xdoc, string nodeName)
        {
            try
            {
                XmlElement xmlElement = xdoc.CreateElement(nodeName);

                return xmlElement;
            }
            catch (Exception ex)
            {
                ////Logger.WriteErrorLog(ex);

                return null;
            }
        }

        /// <summary>
        /// Updates node name
        /// </summary>
        /// <param name="xdoc">XmlDocument</param>
        /// <param name="xmlNode">XmlNode to be updated</param>
        /// <param name="newNodeName">New node name</param>
        /// <returns>Updated XmlNode if successful else null</returns>
        public static XmlNode UpdateNodeName(XmlDocument xdoc, XmlNode xmlNode, string newNodeName)
        {
            try
            {
                string nodeValue = xmlNode.InnerText;

                string innerXml = xmlNode.InnerXml;

                Hashtable ht = GetAttributesNameValueHashTable(xmlNode);

                XmlNode node = xmlNode.ParentNode;

                node.RemoveChild(xmlNode);

                xmlNode = CreateXMLNode(xdoc, newNodeName, new ArrayList(ht.Keys), new ArrayList(ht.Values), nodeValue);

                ht.Clear();

                xmlNode.InnerXml = innerXml;

                node.AppendChild(xmlNode);

                return xmlNode;
            }
            catch (Exception ex)
            {
                ////Logger.WriteErrorLog(ex);

                return null;
            }
        }

        /// <summary>
        /// Updates node value
        /// </summary>
        /// <param name="xmlNode">XmlNode to be updated</param>
        /// <param name="nodeValue">New node value</param>
        /// <returns>Updated XmlNode if successful else false</returns>
        public static XmlNode UpdateNodeValue(XmlNode xmlNode, string nodeValue)
        {
            try
            {
                xmlNode.InnerText = nodeValue;

                return xmlNode;
            }
            catch (Exception ex)
            {
                ////Logger.WriteErrorLog(ex);

                return null;
            }
        }

        /// <summary>
        /// Updates node attributes
        /// </summary>
        /// <param name="xdoc">XmlDocument</param>
        /// <param name="xmlNode">XmlNode to be updated</param>
        /// <param name="newAttributeNameList">Attribute name list</param>
        /// <param name="newAttributeValueList">Attribute value list</param>
        /// <param name="nodeValue">Node value</param>
        /// <returns>Updated XmlNode if successful else false</returns>
        public static XmlNode UpdateNode(XmlDocument xdoc, XmlNode xmlNode, ArrayList newAttributeNameList,
                                         ArrayList newAttributeValueList, string nodeValue)
        {
            try
            {
                string nodeName = xmlNode.Name;

                XmlNode node = xmlNode.ParentNode;

                node.RemoveChild(xmlNode);

                xmlNode = CreateXMLNode(xdoc, nodeName, newAttributeNameList, newAttributeValueList, nodeValue);

                node.AppendChild(xmlNode);

                newAttributeNameList.Clear();

                newAttributeValueList.Clear();

                return xmlNode;
            }
            catch (Exception ex)
            {
                ////Logger.WriteErrorLog(ex);

                return null;
            }
        }

        /// <summary>
        /// Removes a node from xml document
        /// </summary>
        /// <param name="xmlNode">XmlNode</param>
        public static void RemoveNode(XmlNode xmlNode)
        {
            try
            {
                xmlNode.ParentNode.RemoveChild(xmlNode);
            }
            catch (Exception ex)
            {
                ////Logger.WriteErrorLog(ex);
            }
        }

        /// <summary>
        /// Removes a node from xml document
        /// </summary>
        /// <param name="xDoc">XmlDocument</param>
        /// <param name="nodeName">Node name</param>
        public static void RemoveNode(XmlDocument xDoc, string nodeName)
        {
            try
            {
                if (xDoc != null)
                {
                    string xPath = IsNodeExists(xDoc, nodeName);
                    if (xPath.Length > 0)
                    {
                        XmlNode xmlnode = GetXMLNode(xDoc, xPath);

                        xmlnode.ParentNode.RemoveChild(xmlnode);
                    }
                }
            }
            catch (Exception ex)
            {
                ////Logger.WriteErrorLog(ex);
            }
        }

        /// <summary>
        /// Removes all child nodes of the current node
        /// </summary>
        /// <param name="xmlNode">XmlNode</param>
        public static void RemoveAllChildNodes(XmlNode xmlNode)
        {
            try
            {
                for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
                {
                    xmlNode.RemoveChild(xmlNode.ChildNodes[i]);
                }
            }
            catch (Exception ex)
            {
                ////Logger.WriteErrorLog(ex);
            }
        }

        /// <summary>
        /// Gets attribute names and its values hashtable, attribute name is the key and its value is the value
        /// </summary>
        /// <param name="xmlNode">XmlNode</param>
        /// <returns>Hashtable if successful else null</returns>
        public static Hashtable GetAttributesNameValueHashTable(XmlNode xmlNode)
        {
            try
            {
                Hashtable attributesNameValueHashTable = new Hashtable();

                for (int i = 0; i < xmlNode.Attributes.Count; i++)
                {
                    attributesNameValueHashTable.Add(xmlNode.Attributes[i].Name, xmlNode.Attributes[i].Value);
                }

                return attributesNameValueHashTable;
            }
            catch (Exception ex)
            {
                ////Logger.WriteErrorLog(ex);

                return null;
            }
        }

        /// <summary>
        /// Prepends child node to the parent
        /// </summary>
        /// <param name="parentNode">Parent Node</param>
        /// <param name="childNode">Child Node</param>
        public static void PrependNode(XmlNode parentNode, XmlNode childNode)
        {
            parentNode.PrependChild(childNode);
        }

        /// <summary>
        /// Appends child node to parent node
        /// </summary>
        /// <param name="parentNode">Parent Node</param>
        /// <param name="childNode">Child Node</param>
        public static void AppendNode(XmlNode parentNode, XmlNode childNode)
        {
            parentNode.AppendChild(childNode);
        }

        /// <summary>
        /// Appends child node to parent node
        /// </summary>
        /// <param name="parentNode">XmlNode</param>
        /// <param name="childNode">XmlNode</param>
        /// <param name="offset">Offset to move to child nodes</param>
        public static void AppendNodeBefore(XmlNode parentNode, XmlNode childNode, int offset)
        {
            parentNode.InsertBefore(childNode, parentNode.ChildNodes[offset]);
        }

        /// <summary>
        /// Appends child node to parent node
        /// </summary>
        /// <param name="parentNode">XmlNode</param>
        /// <param name="childNode">XmlNode</param>
        /// <param name="offset">Offset to move to child nodes</param>
        public static void AppendNodeAfter(XmlNode parentNode, XmlNode childNode, int offset)
        {
            parentNode.InsertAfter(childNode, parentNode.ChildNodes[offset]);
        }

        /// <summary>
        /// Adds xml element to xml document
        /// </summary>
        /// <param name="root">Xml node root</param>
        /// <param name="xDoc">Xml document</param>
        /// <param name="elementName">Xml element name</param>
        /// <param name="elementValue">Xml element's value</param>
        /// <returns>Xmldocument</returns>
        public static XmlDocument AddXmlElement(XmlNode node, XmlDocument xDoc, string elementName, string elementValue)
        {
            try
            {
                XmlElement xmlElement = xDoc.CreateElement(elementName);

                xmlElement.InnerText = elementValue;

                node.AppendChild(xmlElement);
            }
            catch (Exception ex)
            {
                //Logger.WriteErrorLog(ex);
            }

            return xDoc;
        }

        /// <summary>
        /// Add new attributes to the node specified
        /// </summary>
        /// <param name="root">XmlNode root</param>
        /// <param name="attributeName">Attribute name</param>
        /// <param name="attributeValue">Value for the attribute</param>
        public static void AddAttribute(XmlNode node, string attributeName, string attributeValue)
        {
            /* Remove all the attributes of root */
            node.Attributes.RemoveAll();

            XmlAttribute attr = node.OwnerDocument.CreateAttribute(attributeName);

            attr.Value = attributeValue;

            node.Attributes.Append(attr);
        }

        /// <summary>
        /// Add new attributes to the node specified
        /// </summary>
        /// <param name="node">XmlNode to append atributes</param>
        /// <param name="attributeName">Attribute names</param>
        /// <param name="attributeValue">Values for the attribute</param>
        public static void AddAttribute(XmlNode node, ArrayList attributeName, ArrayList attributeValue)
        {
            /* Remove all the attributes of root */
            node.Attributes.RemoveAll();

            for (int i = 0; i < attributeName.Count; i++)
            {
                XmlAttribute attr = node.OwnerDocument.CreateAttribute(attributeName[i].ToString());

                attr.Value = attributeValue[i].ToString();

                node.Attributes.Append(attr);
            }
        }

        #endregion
    }

