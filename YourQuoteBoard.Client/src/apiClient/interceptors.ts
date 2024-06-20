import { apiClient } from './client';

apiClient.interceptors.request.use(request => {
  //console.log('Starting Request', request);
  return request;
});

apiClient.interceptors.response.use(response => {
  //console.log('Response:', response);
  return response;
}, error => {
  //console.error('Response error:', error);
  return Promise.reject(error);
});

export {};
