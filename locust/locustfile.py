from locust import HttpUser, task

class GCHomePerformanceTest(HttpUser):
    @task
    def GCHomePerformanceGetTest(self):

        headers = {
            "Host": "localhost:4200",
            "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:93.0) Gecko/20100101 Firefox/93.0",
            "Accept": "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8",
            "Accept-Language": "es-ES,es;q=0.8,en-US;q=0.5,en;q=0.3",
            "Accept-Encoding": "gzip, deflate",
            "Connection": "keep-alive",
            "Upgrade-Insecure-Requests": "1",
            "Sec-Fetch-Dest": "document",
            "Sec-Fetch-Mode": "navigate",
            "Sec-Fetch-Site": "none",
            "Sec-Fetch-User": "?1",
            "Cache-Control": "max-age=0",
            "If-None-Match": "W/'3b3-OLWzdonaDCq+L+qoOncVpCmXOCo'"
        }
        self.client.get("/home", headers = headers)
        self.client.get("/cart", headers = headers)
