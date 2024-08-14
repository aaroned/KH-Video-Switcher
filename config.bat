@echo off
netsh http add urlacl url=http://+:7004/ user=\Everyone
netsh advfirewall firewall add rule name="KH Switcher" dir=in action=allow protocol=TCP localport=7004 profile=private remoteip=localsubnet
netsh advfirewall firewall add rule name="KH Switcher" dir=in action=allow protocol=TCP localport=7004 profile=public remoteip=localsubnet