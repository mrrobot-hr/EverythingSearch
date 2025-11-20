# VoidTools Everything — The Fastest Local File Search Engine

[VoidTools Everything](https://www.voidtools.com/) is widely regarded as **the fastest file search engine ever built for Windows**.  
It indexes NTFS volumes almost instantly and makes file searching effectively instantaneous.  
With its built-in HTTP server, Everything becomes a powerful remote search backend suitable for automation, dashboards, or multi-machine search environments.

Everything’s speed, simplicity, and tiny footprint make it the gold standard of local file search.  
**Huge respect to VoidTools — an incredible tool that powers this project.**

---

# MR.ROBOT'S Multi-Server Everything Search UI

A lightweight web UI for searching **multiple Everything servers at once**.  
Results stream in live, and each server is shown as online or offline.

---

## 🔥 Features

- Multi-server search across Everything instances  
- Real-time online/offline server detection  
- Streaming results as servers respond  
- Direct links to files and folders (`http://server:888/...`)  
- Safe HTML escaping  
- Pure vanilla JavaScript (no external dependencies)

---

## 🧠 How It Works

- A server list is defined in JavaScript  
- A `/proxy` backend forwards API calls to each Everything HTTP server  
- Responses are merged, sorted, sanitized, and displayed live  
- Unresponsive servers are marked **offline**

---

# 🚀 Installation & Setup

### 1. Enable Everything’s built-in HTTP server

On **every machine** running Everything:

1. Open **Everything**  
2. Go to **Tools → Options → HTTP Server**  
3. Enable:  
   - ☑ **Enable HTTP Server**  
   - Port (default: `888`)  
   - (Optional) Authentication  
4. Click **OK**

### Important Notes

- The port must match what your proxy/UI expects  
- The machines must be reachable  
- Firewalls must allow inbound traffic to the chosen port  
- To connect machines across networks or remotely, use **Tailscale VPN:**  
  https://tailscale.com/

---

### 2. Set the list of Everything servers

Edit this part of the code to add as many server as you want to search:

```js
const servers = ["laptop", "spansko", "obreska"];
