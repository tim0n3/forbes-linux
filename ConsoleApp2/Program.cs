using System;
using System.Diagnostics;


public class Firewall
{
    string firewall;
    
    public HostFirewall(string firewall)
    {
        this.firewall = firewall;
    }

    public String getFirewall()
    {
        return firewall;
    }

    public void setFirewall(String newFirewall)
    {
        firewall = newfirewall;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please, choose your preferred firewall from one of the following options: ");
            Console.WriteLine("1 /sbin/iptables");
            Console.WriteLine("2 ufw");
            Console.WriteLine("3 nftables");
            Console.WriteLine("4 Exit");
        }

        void firewallChoice(Firewall currentHost)
        {
            Console.WriteLine("What type of firewall deployment would you like");
            Console.WriteLine(@" 1. Laptop
2. Desktop with server functions
3. DDoS protected server
4. Loose rules");
            string? choice = Console.ReadLine();
            string firewallChoice = choice;
            currentHost.setFirewall(currentHost.getFirewall());

        }


        List<Firewall> Firewalls = new List<Firewall>();
        Firewalls.Add(new Firewall("/sbin/iptables"));
        Firewalls.Add(new Firewall("/usr/sbin/ufw"));
        Firewalls.Add(new Firewall("/usr/sbin/nft"));

        // Prompt the user
        Console.WriteLine("Welcome to SimpleFirewallC#!");
        Console.WriteLine("Please, select your preferred Firewall: ");
        String prefFW = "";
        Firewall currentHost;

        while (true)
        {
            try
            {
                prefFW = Console.ReadLine();
                //Check against our db
                currentHost = Firewalls.FirstOrDefault(a.firewall == prefFW);
                if (currentHost != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("This firewall isn't recognised. Please, try again");
                }
            }
            catch
            {
                Console.WriteLine("This firewall isn't recognised. Please, try again");
            }
        }
    }
}
class BastionFirewall
{
    static void Main()
    {
        // lets say we want to run this command:    
        //  t=$(echo 'this is a test'); echo "$t" | grep -o 'is a'
        var output = ExecuteBashCommand(command: "t=$(echo 'this is a test'); echo \"$t\" | grep -o 'is a'");
        var output = ExecuteBashCommand(command: "echo 'prevent smurf attacks.'; echo 1 > /proc/sys/net/ipv4/icmp_echo_ignore_broadcasts; echo 0 > /proc/sys/net/ipv4/conf/all/accept_redirects; echo 'Drop source routed packets.'; echo 0 > /proc/sys/net/ipv4/conf/all/accept_source_route; echo 'prevent SYN Flood and TCP Starvation'; sysctl -w net/ipv4/tcp_syncookies=1; sysctl -w net/ipv4/tcp_timestamps=1; echo 2048 > /proc/sys/net/ipv4/tcp_max_syn_backlog; echo 3 > /proc/sys/net/ipv4/tcp_synack_retries; echo 'Address Spoofing Protection'; echo 1 > /proc/sys/net/ipv4/conf/all/rp_filter; echo 'Disable SYN Packet tracking'; sysctl -w net/netfilter/nf_conntrack_tcp_loose=0");

        // output the result
        Console.WriteLine(output);
    }

    static string ExecuteBashCommand(string command)
    {
        // according to: https://stackoverflow.com/a/15262019/637142
        // thanks to this we will pass everything as one command
        command = command.Replace("\"", "\"\"");

        var proc = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "/bin/bash",
                Arguments = "-c \"" + command + "\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            }
        };

        proc.Start();
        proc.WaitForExit();

        return proc.StandardOutput.ReadToEnd();
    }
}