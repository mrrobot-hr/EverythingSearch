# VoidTools Everything — The Fastest Local File Search Engine

[VoidTools Everything](https://www.voidtools.com/) is widely regarded as **the fastest file search engine ever built for Windows**.  
It indexes NTFS volumes almost instantly and enables real-time querying with almost no system overhead. Its built-in HTTP API makes remote access, automation, and custom dashboards incredibly easy.

Everything’s speed, tiny footprint, and simplicity make it the gold standard for local file search.  
**Huge respect to VoidTools — an unbeatable tool that powers this project.**

---

# MR.ROBOT'S Multi-Server Everything Search UI

This project provides a lightweight web interface that lets you **search multiple Everything servers at once**, combining all results into a single clean table.  
Results stream in live as each server responds, and the interface shows which hosts are currently online.

## 🔥 Features
- **Multi-server search** across multiple Everything instances  
- **Live online/offline detection** per host  
- **Streaming results** as servers respond  
- **Direct file & folder links** (`http://server:888/...`)  
- **Safe HTML escaping** for names and paths  
- **Zero external dependencies** (vanilla JavaScript + Razor page)

## 🧠 How It Works
- A predefined list of servers (e.g. `["laptop", "spansko", "obreska"]`) is queried through a `/proxy` endpoint.  
- Each server returns JSON using the Everything HTTP API.  
- Results from all servers are merged, sorted, sanitized, and displayed in the UI.  
- Servers that don’t respond are marked *offline* while the others continue working normally.

## 📁 Purpose
A fast, clean dashboard for searching files across several computers — ideal for:
- home labs  
- multi-PC setups  
- NAS devices running Everything  
- distributed file storage
