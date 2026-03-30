import http from 'k6/http';
import { sleep, check } from 'k6';

export let options = {
  vus: 50,       // Virtual users
  duration: '1m' // Test duration
};

export default function () {
  let res = http.get('https://localhost:7200/Departments');
  check(res, { 'status was 200': (r) => r.status === 200 });
  sleep(1);
}