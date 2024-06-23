#   docker-compose
-  https://github.com/dockur/windows
-  https://www.youtube.com/watch?v=xhGYobuG508&t=388s

'''
services:
  windows:
    image: dockurr/windows
    container_name: windows
    environment:
      VERSION: "win11"
    devices:
      - /dev/kvm
    cap_add:
      - NET_ADMIN
    ports:
      - 8006:8006
      - 3389:3389/tcp
      - 3389:3389/udp
    stop_grace_period: 2m
'''