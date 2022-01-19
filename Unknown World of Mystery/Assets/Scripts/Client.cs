using System;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class Client
{
    const int port = 8888;
    const string address = "127.0.0.1";

    /// <summary>
    /// �������� ��������� �� ������
    /// </summary>
    /// <param name="username">��� ������������</param>
    /// <param name="message">���������</param>
    /// <returns>����� �������</returns>

    public static string SendingMessage(string username, string message)
    {
        TcpClient tcpClient = null;
        try
        {
            tcpClient = new TcpClient(address, port);
            NetworkStream stream = tcpClient.GetStream();
            while (true)
            {
                // ���� ���������
                message = String.Format("{0}: {1}", username, message);
                // ����������� ��������� � ������ ������
                byte[] data = Encoding.Unicode.GetBytes(message);
                // �������� ���������
                stream.Write(data, 0, data.Length);
                // �������� �����
                data = new byte[64]; // ����� ��� ���������� ������
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                do
                {
                    bytes = stream.Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable);
                message = builder.ToString();
                return message;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            tcpClient.Close();
        }
        return message;
    }
}
