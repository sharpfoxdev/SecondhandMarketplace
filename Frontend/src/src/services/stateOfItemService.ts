import api from '@/services/apiClient';
import { StateOfItem } from '@/types/api/stateOfItem';

export const fetchStatesOfItem = async (): Promise<StateOfItem[]> => {
    const response = await api.get<StateOfItem[]>('/api/StateOfItem');
    return response.data;
};
