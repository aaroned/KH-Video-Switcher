@echo off
netsh http add urlacl url=http://+:7004/ user=\Everyone
pause