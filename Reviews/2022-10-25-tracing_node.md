---
title: node.js tracing
tags: 
layout: article
aside:
  toc: true
sidebar:
  nav: layouts
date:  2022-10-17
modify_date: 2022-10-17 14:18:39
---

### Node.js

- [Node.js v18.11.0 文档](http://nodejs.cn/api/tls.html), [en](https://nodejs.org/api/tls.html#tls-ssl)
  - tls 安全传输层(Transport Layer Security )
    - node:tls 模块提供了构建在 OpenSSL 之上的传输层安全 (TLS) 和安全套接字层 (Secure Socket Layer, SSL) 协议的实现。 该模块可以使用以下方式访问：`const tls = require('node:tls');`


### paid project
- [IBM Instana](https://www.ibm.com/docs/en/instana-observability/current?topic=instana-monitoring-websites)
  - SaaS charge: 75USD/month/host

### freewares
- [tcpflow](https://www.baeldung.com/linux/monitoring-http-requests-network-interfaces)
  - installation
    - `sudo dnf install tcpflow`
  - locate the network name：`ifconfig -a`    
  - start listening
    - certain port
      - `sudo tcpflow -p -c -i em1 port 8084 | grep -oE '(GET|POST) .* HTTP/1.[01]|Host: .*'`
    - all ports from interal host ip's
      - `sudo tcpflow -p -c -i em1 | grep ^200.200|grep -E "(GET|PUT|HEAD|POST) .* HTTP/1.[01]|Host: .*"`

- httpry
  - [source code](https://github.com/jbittel/httpry)      
  - [man](https://linux.die.net/man/1/httpry)
  - mac http monitoring：`sudo  ~/MyPrograms/httpry/httpry -i ppp0`
  - ports
    - default ports 80 and 8080
    - other ports
      - `sudo httpry -i ppp0 tcp 8084 or 8085 or 8086`
  - features：timestamp and ip shown in same line

```bash
#timestamp,source-ip,dest-ip,direction,method,host,request-uri,  http-version,status-code,reason-phrase
2022-10-25 13:44:21.153 118.163.33.43   125.229.149.182 >       GET     125.229.149.182 /LeafletDigitizer/libs/images/dig_custom.svg  HTTP/1.1 -       -
2022-10-25 13:44:21.153 125.229.149.182 118.163.33.43   <       -       -       -       HTTP/1.1        200     OK
2022-10-25 13:44:21.153 125.229.149.182 118.163.33.43   <       -       -       -       HTTP/1.1        200     OK
2022-10-25 13:44:49.820 125.229.149.182 125.229.149.182 >       OPTIONS -       *       HTTP/1.0        -       -
2022-10-25 13:44:49.824 125.229.149.182 125.229.149.182 >       OPTIONS -       *       HTTP/1.0        -       -
```

### httpry settings
- requests per second(rps) statistics(-s) during -t SECONDs

```bash
$ sudo httpry -s -t 10 -i ppp0 tcp 8084 or 8085 or 8086
httpry version 0.1.8 -- HTTP logging and information retrieval tool
Copyright (c) 2005-2014 Jason Bittel <jason.bittel@gmail.com>
Starting capture on ppp0 interface
2022-10-25 14:24:59     totals  0.40 rps
2022-10-25 14:25:09     totals  0.20 rps
2022-10-25 14:25:19     totals  0.12 rps
2022-10-25 14:25:29     totals  0.09 rps
2022-10-25 14:25:39     totals  0.11 rps
2022-10-25 14:25:49     totals  0.24 rps
2022-10-25 14:25:57     125.229.149.182:8085    3 rps
2022-10-25 14:25:57     totals  0.44 rps
2022-10-25 14:26:07     totals  0.40 rps
2022-10-25 14:26:17     totals  0.35 rps
2022-10-25 14:26:27     totals  0.31 rps
2022-10-25 14:26:37     totals  0.28 rps
2022-10-25 14:26:47     totals  0.26 rps
2022-10-25 14:26:57     totals  0.24 rps
2022-10-25 14:27:07     totals  0.22 rps
```

- **-n** count     set number of HTTP packets to parse
  - 收到n次的request就自動停止程式

